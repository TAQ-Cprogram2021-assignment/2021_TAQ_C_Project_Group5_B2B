using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class WinInterface : MonoBehaviour
{

    //������ʵ��Ŀ�꣬���ʱ��
    public Text youTimeText;
    public Text goalTimeText;
    public Text bestTimeText;

    //�Ǽ�
    private int starLevel;

    //���ǵ�ͼƬ���
    public Image firstStar;
    public Image secondStar;
    public Image thirdStar;

    //ʵ�����ǺͿ�������
    private Sprite emptyStar;
    private Sprite filledStar;

    //����ı�
    public Text coinNumText;

    private void OnEnable()
    {
        //��ʾ��ʵʱ��
        DisplayTime(LevelController.Instance.playTime, youTimeText);

        //��ʾĿ��ʱ��
        DisplayTime(Myclass.levelThresholdTime[Myclass.currentLevelIndex, 0], goalTimeText);

        //��ȡ���ʱ��
        float tempBestTime = PlayerPrefs.GetFloat("bestTime" + Myclass.currentLevelIndex, float.MaxValue);
        if(LevelController.Instance.playTime< tempBestTime)
        {
            tempBestTime = LevelController.Instance.playTime;

            //��¼�µ����ʱ��
            PlayerPrefs.SetFloat("bestTime" + Myclass.currentLevelIndex, tempBestTime);
        }
        //��ʾ���ʱ��
        DisplayTime(tempBestTime, bestTimeText);

        //��ȡʵ�Ŀ�������ͼƬ
        emptyStar = Resources.Load<Sprite>("Prefab/Star/EmptyStar");
        filledStar = Resources.Load<Sprite>("Prefab/Star/FilledStar");

        //�����Ǽ�
        CaclculateStarLevel();

        //��ʾ�Ǽ�
        DisplayStarLevel();

        //��ʾ�����
        DisplayCoin();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //��float��ʽʱ��תΪ��00��00��
    private void DisplayTime(float targetTime, Text targetText)
    {
        TimeSpan tempTimeSpan = new TimeSpan(0, 0, (int)targetTime);

        targetText.text = tempTimeSpan.Minutes.ToString("00") + ":" + tempTimeSpan.Seconds.ToString("00");

    }

    //���㱾���Ǽ�
    private void CaclculateStarLevel()
    {
        //3��
        if (LevelController.Instance.playTime <= Myclass.levelThresholdTime[Myclass.currentLevelIndex, 0])
        {
            starLevel = 3;
        }
        //2��
        else if(LevelController.Instance.playTime<= Myclass.levelThresholdTime[Myclass.currentLevelIndex, 1])
        {
            starLevel = 2;
        }
        else
        {
            starLevel = 1;
        }
    }

    //��ʾ�����Ǽ�
    private void DisplayStarLevel()
    {
        //3��
        if (starLevel == 3)
        {
            firstStar.sprite = filledStar;
            secondStar.sprite = filledStar;
            thirdStar.sprite = filledStar;
        }
        //2��
        else if (starLevel == 2)
        {
            firstStar.sprite = filledStar;
            secondStar.sprite = filledStar;
            thirdStar.sprite = emptyStar;
        }
        else if (starLevel == 1)
        {
            firstStar.sprite = filledStar;
            secondStar.sprite = emptyStar;
            thirdStar.sprite = emptyStar;
        }
    }

    //���㱾�ؽ��
    private void DisplayCoin()
    {
        //���ֻ��
        int tempCoin = 50 * starLevel;
        //��ʾ
        coinNumText.text = "+" + tempCoin;

        //��ȡ�ܽ��
        Myclass.totalCoinNum = PlayerPrefs.GetInt("totalCoinNum", 0);
        //���½��
        Myclass.totalCoinNum += tempCoin;
        //���´���
        PlayerPrefs.SetInt("totalCoinNum", Myclass.totalCoinNum);
    }

    public void PlayAgainButtonClick()
    {
        //���¼��عؿ�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadScene(string sceneName)
    {   //ѡ�غ���
        SceneManager.LoadScene(sceneName);
    }

    public void NextLevel()
    {   //������һ��
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
