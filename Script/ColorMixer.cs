using UnityEngine;
using System.Collections;

public class ColorMixer : MonoBehaviour
{
    //进入该混合器的两个小球
    private GameObject firstBall;
    private GameObject secondBall;

    //两个小球的颜色索引
    private int firstColorIndex;
    private int secondColorIndex;

    //混合之后的颜色索引
    private int mixedColorIndex;

    //进入的小球计数器
    private int enterBallNum;

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
        //初始时，进入小球数为0
        enterBallNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //当该脚本组件不可用时
    void OnDisable()
    {
    }

    //当别的碰撞体进入混合器的触发器时
    void OnTriggerEnter2D(Collider2D coll)
    {
        //如果进入的物体是物理小球
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //小球计数
            enterBallNum++;

            //如果进入的是第一个小球
            if (enterBallNum == 1)
            {
                //速度为0
                coll.attachedRigidbody.velocity = Vector2.zero;

                //重力系数为0
                coll.attachedRigidbody.gravityScale = 0;

                //位置修正
                coll.transform.position = this.transform.position;

                //记录该小球
                firstBall = coll.gameObject;

                //获取该小球的颜色索引
                firstColorIndex = firstBall.GetComponent<PhysicsBall>().colorIndex;
            }

            //如果进入的是第二个小球
            if (enterBallNum == 2)
            {
                //速度为0
                coll.attachedRigidbody.velocity = Vector2.zero;

                //重力系数为0
                coll.attachedRigidbody.gravityScale = 0;

                //位置修正
                coll.transform.position = this.transform.position;

                //记录该小球
                secondBall = coll.gameObject;

                //获取该小球的颜色索引
                secondColorIndex = secondBall.GetComponent<PhysicsBall>().colorIndex;

                //计算混合之后的小球的颜色索引
                mixedColorIndex = Myclass.ColorMixingTable[firstColorIndex, secondColorIndex];

                //销毁第二个小球
                Destroy(secondBall);

                //修改第一个小球的颜色索引
                firstBall.GetComponent<PhysicsBall>().colorIndex = mixedColorIndex;

                //修改第一个小球的图片颜色
                firstBall.GetComponent<SpriteRenderer>().color = Resources.Load<SpriteRenderer>("Prefab/PhysicsBall/" + mixedColorIndex).color;

                //第一个小球重力系数恢复
                firstBall.GetComponent<Rigidbody2D>().gravityScale = 1;

                //进入小球计数清0
                enterBallNum = 0;
            }
        }
    }
}
