using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//游戏状态
public enum GameState
{
        Load,
        Playing,
        Win,
        ColorError,
        NumError
}
public class Myclass
{   //当前状态
    public static GameState currentGameState = GameState.Load;

    //当前关卡索引
    public static int currentLevelIndex = 3;
    

    //游戏每关时间分界
    public static float[,] levelThresholdTime ={
                                                    {8,15 },
                                                    {10,15 },
                                                    {15,20 },
                                                    {10,15 },
                                                    {15,20 },
                                                    {15,20 },
                                                    {15,20 },
                                                    {15,20},
                                                    {25,35 },
                                                    {20,25 },
                                                    {25,35 },
                                                    {25,35 },




    };

    //玩家总金币
    public static int totalCoinNum = 0;

    //游戏中各个小球颜色混合表,0红，1绿，2蓝，3黄，4橙，5紫，6灰
    public static int[,] ColorMixingTable = {
                                                {0,6,5,4,6,6,6},
                                                {6,1,6,6,6,6,6},
                                                {5,6,2,6,6,6,6},
                                                {4,6,6,3,6,6,6},
                                                {6,6,6,6,4,6,6},
                                                {6,6,6,6,6,5,6},
                                                {6,6,6,6,6,6,6}
                                            };
}