using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //两个子物体的引用
    private GameObject child0;
    private GameObject child1;

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
        //获取子物体的引用
        child0 = this.transform.GetChild(0).gameObject;
        child1 = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //当该脚本组件不可用时
    void OnDisable()
    {
    }

    //当别的碰撞体离开该触发器时，执行操作
    void OnTriggerExit2D(Collider2D coll)
    {
        //离开的物体是物理小球
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //子物体的激活状态置反
            child0.SetActive(!child0.activeSelf);
            child1.SetActive(!child1.activeSelf);
        }
    }
}
