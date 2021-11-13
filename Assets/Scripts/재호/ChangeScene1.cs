using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene1 : MonoBehaviour
{
    string nam;
    void Start()
    {
       nam = this.name;
    }

    public void ChangeSceneBtn2()
    {
        Debug.Log("버튼누름");
        if (nam == "T1Btn") SceneManager.LoadScene("Explain");
    }

    public void ChangeSceneBtn()
    {
        Debug.Log("버튼누름");
        if(nam=="StartBtn") SceneManager.LoadScene("InGame");
    }

    public void ChangeSceneBtn1()
    {
        Debug.Log("버튼누름");
        if (nam == "StartBtn1") SceneManager.LoadScene("InGame");
    }

    public void QuitGameBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}

