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
    /// ���� ��ذ�VibrationManager.java�ļ��е�package xxx.xxxx.xxxx�ĳ���unity����һ��;
    /// </summary>
    private string packageName;
    /// <summary>
    /// .java �ļ�������
    /// </summary>
    private string javaClassName;

    void Init()
    {
        packageName = Application.identifier;
        javaClassName = "VibrationManager";
        // ����AndroidJavaClass���󲢻�ȡ��ǰActivity��ʵ��
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        // ����AndroidJavaObject����ʵ����Java��
        androidPlugin = new AndroidJavaObject($"{packageName}.{javaClassName}", currentActivity);
    }

    // ����Java���е��ֻ��𶯷���
    public void Vibrate(long time)
    {
        androidPlugin.Call("vibrate", time);
    }

    // ����Java���е���ʾ��Ϣ�����򷽷�
    public void ShowMessage(string message)
    {
        androidPlugin.Call("showMessage", message);
    }

    // ����Java���еķ����������շ���ֵ
    public string GetReturnValue()
    {
        return androidPlugin.Call<string>("getReturnValue");
    }
}
