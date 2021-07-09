using UnityEngine;
using System.Collections;

public class Dye : MonoBehaviour
{
    //染色器的颜色索引
    public int colorIndex;

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

    //当别的碰撞体进入染色器的触发器时
    void OnTriggerEnter2D(Collider2D coll)
    {
        //如果进入的物体是物理小球
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //修改物理小球的颜色索引
            coll.gameObject.GetComponent<PhysicsBall>().colorIndex = this.colorIndex;

            //修改物理小球的图片颜色
            coll.gameObject.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
        }
    }
}
