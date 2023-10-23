using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCallAndroidManager 
{
    private static UnityCallAndroidManager instance;
    public static UnityCallAndroidManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UnityCallAndroidManager();
            return instance;
        }
    }
    private UnityCallAndroidManager()
    {
        Init();
    }
    private static AndroidJavaObject androidPlugin;

    /// <summary>
    /// 包名 务必把VibrationManager.java文件中的package xxx.xxxx.xxxx改成与unity包名一致;
    /// </summary>
    private string packageName;
    /// <summary>
    /// .java 文件的类名
    /// </summary>
    private string javaClassName;

    void Init()
    {
        packageName = Application.identifier;
        javaClassName = "VibrationManager";
        // 创建AndroidJavaClass对象并获取当前Activity的实例
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        // 创建AndroidJavaObject对象并实例化Java类
        androidPlugin = new AndroidJavaObject($"{packageName}.{javaClassName}", currentActivity);
    }

    // 调用Java类中的手机震动方法
    public void Vibrate(long time)
    {
        androidPlugin.Call("vibrate", time);
    }

    // 调用Java类中的显示消息弹出框方法
    public void ShowMessage(string message)
    {
        androidPlugin.Call("showMessage", message);
    }

    // 调用Java类中的方法，并接收返回值
    public string GetReturnValue()
    {
        return androidPlugin.Call<string>("getReturnValue");
    }
}
