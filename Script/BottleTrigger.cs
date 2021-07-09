using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleTrigger : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
    }

    //当该脚本组件不可用时
    void OnDisable()
    {
    }

    //当其他的碰撞体进入该物体时，执行的操作
    void OnTriggerEnter2D(Collider2D coll)
    {
        //如果进入的碰撞体是物理小球
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //位置修正
            coll.transform.position = this.transform.position;

            //速度修正
            coll.attachedRigidbody.velocity = 10 * this.transform.up;
        }
    }
}

