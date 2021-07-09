using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleButton : MonoBehaviour
{
    //该小球的颜色索引
    public int colorIndex;

    //生成拖动小球
    private GameObject tempDragBall;

    //鼠标位置
    private Vector3 currentMousePosition;

    //3D射线碰撞信息
    private RaycastHit hitInfo3D;

    //射线层标记
    private int hitMask;

    // Start is called before the first frame update
    void Start()
    {
        //计算射线碰撞层标记
        hitMask += 1 << LayerMask.NameToLayer("Entrance");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     //  执行鼠标按下
     public void MarbleButtonDown()
    {
        //计算鼠标当前坐标
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePosition.z = 0;

        //生成对应拖动小球
        tempDragBall = Instantiate(Resources.Load<GameObject>("Prefab/DragBall/" + colorIndex),
                                  currentMousePosition,
                                  Quaternion.identity) as GameObject;

    }

    //  执行鼠标松开
    public void MarbleButtonUp()
    {
        //销毁临时小球
        Destroy(tempDragBall);

        //生成3D射线
        Ray testRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //发射射线
       bool hitresult= Physics.Raycast(testRay, out hitInfo3D, Camera.main.farClipPlane,hitMask);

        //射线碰到
        if (hitresult)
        {
            //在入口生成小球
            Instantiate(Resources.Load<GameObject>("Prefab/PhysicsBall/" + colorIndex),
                        hitInfo3D.transform.position, Quaternion.identity);
           
        }
    }
}
