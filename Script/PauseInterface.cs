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
    {   //�ر���ͣ����
        pauseInterface.SetActive(false);
        //��ʱ�ָ�
        Time.timeScale = 1f;
    }

    public void Pause()
    {   //������ͣ����
        pauseInterface.SetActive(true);
        //��ʱֹͣ
        Time.timeScale = 0f;

    }

    public void LoadScene(string sceneName)
    {   //�����л�����
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void QuitButtonClick()
    {
        //�˳�����
        Application.Quit();
    }
}
