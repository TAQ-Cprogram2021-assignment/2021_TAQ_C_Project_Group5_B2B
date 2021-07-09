using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    //小球倒出之前的角速度
    public float trippingAngleSpeed;

    //小球倒出之后的角速度
    public float returnAngleSpeed;

    //翻斗的容量
    public int bucketCapacity;

    //bool值，指示翻斗是否进入旋转状态
    private bool rotateEnable;

    //翻斗的旋转类型，0表示小球倒出之前的旋转，1表示小球倒出之后的旋转
    private int rotateState;

    //翻斗所转过的总角度的计数
    private float angleCount;

    //进入小球的计数
    private int enterBallNum;

    //离开小球的计数
    private int exitBallNum;

    //翻斗的初始旋转
    private Vector3 originalEulerAngle;

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
        //初始时，翻斗不旋转
        rotateEnable = false;

        //初始时，角度计数为0
        angleCount = 0;

        //初始时，进入和离开小球数均为0
        enterBallNum = 0;
        exitBallNum = 0;

        //记录初始欧拉角
        originalEulerAngle = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //如果翻斗进入旋转状态
        if (rotateEnable)
        {
            //如果小球尚未倒出
            if (rotateState == 0)
            {
                //旋转
                this.transform.Rotate(Vector3.forward, trippingAngleSpeed * Time.deltaTime);

                //角度计数递增
                angleCount += Mathf.Abs(trippingAngleSpeed * Time.deltaTime);
            }

            //如果小球已经倒出
            if (rotateState == 1)
            {
                //旋转
                this.transform.Rotate(Vector3.forward, returnAngleSpeed * Time.deltaTime);

                //角度计数递减
                angleCount -= Mathf.Abs(returnAngleSpeed * Time.deltaTime);

                //如果角度达到0
                if (angleCount <= 0)
                {
                    //退出旋转状态
                    rotateEnable = false;

                    //修正旋转为初始旋转
                    this.transform.eulerAngles = originalEulerAngle;

                    //进入、离开小球数清0
                    enterBallNum = 0;
                    exitBallNum = 0;

                    //角度计数归0
                    angleCount = 0;
                }
            }
        }
    }

    //当该脚本组件不可用时
    void OnDisable()
    {
    }

    //当别的碰撞体进入该触发器时
    void OnTriggerEnter2D(Collider2D coll)
    {
        //如果进入的物体是物理小球
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //进入小球计数
            enterBallNum++;

            //如果进入小球数达到翻斗容量
            if (enterBallNum == bucketCapacity)
            {
                //设置该小球的重力系数
                coll.attachedRigidbody.gravityScale = 1.7F;

                //翻斗进入旋转状态
                rotateEnable = true;

                //小球倒出之前的旋转
                rotateState = 0;
            }
        }
    }

    //当别的碰撞体离开该触发器时
    void OnTriggerExit2D(Collider2D coll)
    {
        //如果离开的物体是物理小球
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //离开小球计数
            exitBallNum++;

            //如果离开小球数达到翻斗容量
            if (exitBallNum == bucketCapacity)
            {
                //翻斗进入旋转状态
                rotateEnable = true;

                //小球倒出之后的旋转
                rotateState = 1;
            }
        }
    }
}

