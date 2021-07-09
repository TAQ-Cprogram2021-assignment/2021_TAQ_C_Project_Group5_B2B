using UnityEngine;
using System.Collections;

public class Dye : MonoBehaviour
{
    //Ⱦɫ������ɫ����
    public int colorIndex;

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

    //�������ײ�����Ⱦɫ���Ĵ�����ʱ
    void OnTriggerEnter2D(Collider2D coll)
    {
        //������������������С��
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //�޸�����С�����ɫ����
            coll.gameObject.GetComponent<PhysicsBall>().colorIndex = this.colorIndex;

            //�޸�����С���ͼƬ��ɫ
            coll.gameObject.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
        }
    }
}
