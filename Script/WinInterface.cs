using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class WinInterface : MonoBehaviour
{

    //本局真实，目标，最佳时间
    public Text youTimeText;
    public Text goalTimeText;
    public Text bestTimeText;

    //星级
    private int starLevel;

    //星星的图片组件
    public Image firstStar;
    public Image secondStar;
    public Image thirdStar;

    //实心星星和空心星星
    private Sprite emptyStar;
    private Sprite filledStar;

    //金币文本
    public Text coinNumText;

    private void OnEnable()
    {
        //显示真实时间
        DisplayTime(LevelController.Instance.playTime, youTimeText);

        //显示目标时间
        DisplayTime(Myclass.levelThresholdTime[Myclass.currentLevelIndex, 0], goalTimeText);

        //读取最佳时间
        float tempBestTime = PlayerPrefs.GetFloat("bestTime" + Myclass.currentLevelIndex, float.MaxValue);
        if(LevelController.Instance.playTime< tempBestTime)
        {
            tempBestTime = LevelController.Instance.playTime;

            //记录新的最佳时间
            PlayerPrefs.SetFloat("bestTime" + Myclass.currentLevelIndex, tempBestTime);
        }
        //显示最佳时间
        DisplayTime(tempBestTime, bestTimeText);

        //获取实心空心星星图片
        emptyStar = Resources.Load<Sprite>("Prefab/Star/EmptyStar");
        filledStar = Resources.Load<Sprite>("Prefab/Star/FilledStar");

        //计算星级
        CaclculateStarLevel();

        //显示星级
        DisplayStarLevel();

        //显示金币数
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
    //将float格式时间转为“00：00”
    private void DisplayTime(float targetTime, Text targetText)
    {
        TimeSpan tempTimeSpan = new TimeSpan(0, 0, (int)targetTime);

        targetText.text = tempTimeSpan.Minutes.ToString("00") + ":" + tempTimeSpan.Seconds.ToString("00");

    }

    //计算本关星级
    private void CaclculateStarLevel()
    {
        //3星
        if (LevelController.Instance.playTime <= Myclass.levelThresholdTime[Myclass.currentLevelIndex, 0])
        {
            starLevel = 3;
        }
        //2星
        else if(LevelController.Instance.playTime<= Myclass.levelThresholdTime[Myclass.currentLevelIndex, 1])
        {
            starLevel = 2;
        }
        else
        {
            starLevel = 1;
        }
    }

    //显示本关星级
    private void DisplayStarLevel()
    {
        //3星
        if (starLevel == 3)
        {
            firstStar.sprite = filledStar;
            secondStar.sprite = filledStar;
            thirdStar.sprite = filledStar;
        }
        //2星
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

    //计算本关金币
    private void DisplayCoin()
    {
        //本局获得
        int tempCoin = 50 * starLevel;
        //显示
        coinNumText.text = "+" + tempCoin;

        //读取总金币
        Myclass.totalCoinNum = PlayerPrefs.GetInt("totalCoinNum", 0);
        //更新金币
        Myclass.totalCoinNum += tempCoin;
        //重新存入
        PlayerPrefs.SetInt("totalCoinNum", Myclass.totalCoinNum);
    }

    public void PlayAgainButtonClick()
    {
        //重新加载关卡
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadScene(string sceneName)
    {   //选关函数
        SceneManager.LoadScene(sceneName);
    }

    public void NextLevel()
    {   //进入下一关
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
