using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleTrigger : MonoBehaviour
{
    //����
    void Awake()
    {
    }

    //���ýű��������ʱ
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

    //���ýű����������ʱ
    void OnDisable()
    {
    }

    //����������ײ����������ʱ��ִ�еĲ���
    void OnTriggerEnter2D(Collider2D coll)
    {
        //����������ײ��������С��
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //λ������
            coll.transform.position = this.transform.position;

            //�ٶ�����
            coll.attachedRigidbody.velocity = 10 * this.transform.up;
        }
    }
}

