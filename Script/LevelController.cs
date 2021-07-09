using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelController : MonoBehaviour
{
    //����
    public static LevelController Instance;

    public int levelnum;

    //ʧ�ܽ���
    public GameObject defeatInterface;

    //ʤ������
    public GameObject winInterface;

    //������Ϸʱ��
    public float playTime;

    //����������Ϣ
    private Basket[] basketArray;
    private void Awake()
    {   //������ֵ
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //��Ϸ״̬Ϊplaying
        Myclass.currentGameState = GameState.Playing;

        //�������
        playTime = 0;

        //��ȡ������
        basketArray = GameObject.FindObjectsOfType<Basket>();
    }

    // Update is called once per frame
    void Update()
    {
        //�����Ϸ����play״̬
        if (Myclass.currentGameState == GameState.Playing)
        {
            //�������
            playTime += Time.deltaTime;
        }
       
    }

    //��Ϸ״̬����
    public void GameStateRefresh()
    {
        //���Ϊplay״̬
        if (Myclass.currentGameState == GameState.Playing)
        {
            //�����ɫ��
            if (ColorErrorJudge())
            {
                Myclass.currentGameState = GameState.ColorError;
                //ʧ�ܽ��漤��
                defeatInterface.SetActive(true);
            }
            //�����Ŀ��
            else if (NumErrorJudge())
            {
                Myclass.currentGameState = GameState.NumError;
                //ʧ�ܽ��漤��
                defeatInterface.SetActive(true);
            }
            else if(WinJudge())
            {
                Myclass.currentGameState = GameState.Win;
                //ʤ�����漤��
                winInterface.SetActive(true);
            }
        }
    }

    //��ɫ�����ж�
    private bool ColorErrorJudge()
    {
        //��������
        for (int i = 0; i < basketArray.Length; i++)
        {
            if(basketArray[i].basketState ==-1)
            {
                //����
                return true;
            }
        }
        return false;
    }
    //��Ŀ�����ж�
    private bool NumErrorJudge()
    {
        //��������
        for (int i = 0; i < basketArray.Length; i++)
        {
            if (basketArray[i].basketState == -2)
            {
                //����
                return true;
            }
        }
        return false;
    }

    //��ɫ�����ж�
    private bool WinJudge()
    {
        //��������
        for (int i = 0; i < basketArray.Length; i++)
        {
            if (basketArray[i].basketState != 1)
            {
                //��δʤ��
                return false;
            }
        }
        return true;
    }

    
}
