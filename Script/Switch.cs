using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //���������������
    private GameObject child0;
    private GameObject child1;

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
        //��ȡ�����������
        child0 = this.transform.GetChild(0).gameObject;
        child1 = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //���ýű����������ʱ
    void OnDisable()
    {
    }

    //�������ײ���뿪�ô�����ʱ��ִ�в���
    void OnTriggerExit2D(Collider2D coll)
    {
        //�뿪������������С��
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //������ļ���״̬�÷�
            child0.SetActive(!child0.activeSelf);
            child1.SetActive(!child1.activeSelf);
        }
    }
}
