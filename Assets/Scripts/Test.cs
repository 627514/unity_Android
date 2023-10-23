using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    void Start()
    {
        button1.onClick.AddListener(() => { UnityCallAndroidManager.Instance.Vibrate(500); });
        button2.onClick.AddListener(() => { UnityCallAndroidManager.Instance.ShowMessage("µ÷ÓÃ"); });
        button3.onClick.AddListener(() => { var code= UnityCallAndroidManager.Instance.GetReturnValue(); Debug.Log(code); }); 
    }

}
