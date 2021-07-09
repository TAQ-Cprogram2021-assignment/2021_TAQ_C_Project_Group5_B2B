using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    //篮子颜色索引
    public int colorIndex;

    //篮子状态，0为空，1为颜色对，-1为颜色错，-2为超过一个
    public int basketState;

    //篮子的堆叠的层索引
    public int pileIndex;

    //穿过该篮子的小球的数目
    private int exitBallNum;

    //自身的多边形碰撞体组件
    private PolygonCollider2D selfPolyCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        //初始时，篮子为空
        basketState = 0;

        //初始时，离开的小球数为0
        exitBallNum = 0;

        //自身的多边形碰撞体组件
        selfPolyCollider2D = this.GetComponent<PolygonCollider2D>();

        //根据离开小球数和堆叠层索引判断多边形碰撞体组件的激活与禁用状态
        selfPolyCollider2D.enabled = (exitBallNum >= pileIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //小球进入
   private void OnTriggerEnter2D(Collider2D coll)
    {
        //如果小球进入
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall") &&
            selfPolyCollider2D.enabled == true)
        {   //如果篮子空
            if (basketState == 0)
            {
                //获取目标小球physicsball组件
                PhysicsBall tempPhysicsBall = coll.transform.GetComponent<PhysicsBall>();
                //如果颜色对
                if (this.colorIndex == tempPhysicsBall.colorIndex)
                {
                    basketState = 1;
                    
                }
                else
                {
                basketState = -1;
                }
            }
            else
            {
                basketState = -2;
            }

            //更新篮子状态
            LevelController.Instance.GameStateRefresh();
        }
    }
    //当其他的碰撞体离开该物体时，执行的操作
    void OnTriggerExit2D(Collider2D coll)
    {
        //如果进入的碰撞体是物理小球
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //离开小球数+1
            exitBallNum++;

            //根据离开小球数和堆叠层索引判断多边形碰撞体组件的激活与禁用状态
            selfPolyCollider2D.enabled = (exitBallNum >= pileIndex);
        }
    }
}
