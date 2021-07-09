using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//��Ϸ״̬
public enum GameState
{
        Load,
        Playing,
        Win,
        ColorError,
        NumError
}
public class Myclass
{   //��ǰ״̬
    public static GameState currentGameState = GameState.Load;

    //��ǰ�ؿ�����
    public static int currentLevelIndex = 3;
    

    //��Ϸÿ��ʱ��ֽ�
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

    //����ܽ��
    public static int totalCoinNum = 0;

    //��Ϸ�и���С����ɫ��ϱ�,0�죬1�̣�2����3�ƣ�4�ȣ�5�ϣ�6��
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