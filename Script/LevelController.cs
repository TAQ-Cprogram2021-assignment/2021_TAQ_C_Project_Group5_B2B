using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelController : MonoBehaviour
{
    //单例
    public static LevelController Instance;

    public int levelnum;

    //失败界面
    public GameObject defeatInterface;

    //胜利界面
    public GameObject winInterface;

    //本局游戏时间
    public float playTime;

    //储存篮子信息
    private Basket[] basketArray;
    private void Awake()
    {   //单例赋值
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //游戏状态为playing
        Myclass.currentGameState = GameState.Playing;

        //计算归零
        playTime = 0;

        //获取篮子数
        basketArray = GameObject.FindObjectsOfType<Basket>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果游戏处于play状态
        if (Myclass.currentGameState == GameState.Playing)
        {
            //计算递增
            playTime += Time.deltaTime;
        }
       
    }

    //游戏状态更新
    public void GameStateRefresh()
    {
        //如果为play状态
        if (Myclass.currentGameState == GameState.Playing)
        {
            //如果颜色错
            if (ColorErrorJudge())
            {
                Myclass.currentGameState = GameState.ColorError;
                //失败界面激活
                defeatInterface.SetActive(true);
            }
            //如果数目错
            else if (NumErrorJudge())
            {
                Myclass.currentGameState = GameState.NumError;
                //失败界面激活
                defeatInterface.SetActive(true);
            }
            else if(WinJudge())
            {
                Myclass.currentGameState = GameState.Win;
                //胜利界面激活
                winInterface.SetActive(true);
            }
        }
    }

    //颜色错误判断
    private bool ColorErrorJudge()
    {
        //遍历篮子
        for (int i = 0; i < basketArray.Length; i++)
        {
            if(basketArray[i].basketState ==-1)
            {
                //返回
                return true;
            }
        }
        return false;
    }
    //数目错误判断
    private bool NumErrorJudge()
    {
        //遍历篮子
        for (int i = 0; i < basketArray.Length; i++)
        {
            if (basketArray[i].basketState == -2)
            {
                //返回
                return true;
            }
        }
        return false;
    }

    //颜色错误判断
    private bool WinJudge()
    {
        //遍历篮子
        for (int i = 0; i < basketArray.Length; i++)
        {
            if (basketArray[i].basketState != 1)
            {
                //尚未胜利
                return false;
            }
        }
        return true;
    }

    
}
