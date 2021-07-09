using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    //瓶口朝向的角度数组
    public float[] angleArray;

    //当前瓶口朝向的角度在角度数组中的索引
    private int currentAngleIndex;

    //2D射线的碰撞信息
    private RaycastHit2D hitInfo2D;

    //射线碰撞的层标记
    private int hitMask;

    //唤醒
    void Awake()
    {
    }

    //当该脚本组件可用时
    void OnEnable()
    {
    }

    // Use this for initialization
    void Start()
    {
        //初始时，角度索引为0
        currentAngleIndex = 0;

        //射线碰撞的层标记
        hitMask += 1 << LayerMask.NameToLayer("Bottle");
    }

    // Update is called once per frame
    void Update()
    {
        //如果游戏处于Playing状态，并且鼠标按下
        if (Myclass.currentGameState == GameState.Playing && Input.GetMouseButtonDown(0))
        {
            //获得鼠标位置
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //如果鼠标位置在瓶子的碰撞体的范围之内
            if (this.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
            {
                //发射2D射线
                hitInfo2D = Physics2D.Raycast(mousePosition, Vector3.forward, Camera.main.farClipPlane, hitMask);

                //如果射线碰撞到了瓶子
                if (hitInfo2D)
                {
                    //角度索引更新
                    currentAngleIndex = (currentAngleIndex + 1) % angleArray.Length;

                    //改变瓶子朝向
                    this.transform.eulerAngles = Vector3.forward * angleArray[currentAngleIndex];
                }
            }
        }
    }

    //当该脚本组件不可用时
    void OnDisable()
    {
    }
}
