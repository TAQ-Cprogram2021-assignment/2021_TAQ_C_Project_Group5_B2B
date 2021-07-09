using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseInterface : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseInterface;

    // Update is called once per frame
    
    public void Resume()
    {   //关闭暂停界面
        pauseInterface.SetActive(false);
        //计时恢复
        Time.timeScale = 1f;
    }

    public void Pause()
    {   //激活暂停界面
        pauseInterface.SetActive(true);
        //计时停止
        Time.timeScale = 0f;

    }

    public void LoadScene(string sceneName)
    {   //场景切换函数
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void QuitButtonClick()
    {
        //退出程序
        Application.Quit();
    }
}
