using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    //С�򵹳�֮ǰ�Ľ��ٶ�
    public float trippingAngleSpeed;

    //С�򵹳�֮��Ľ��ٶ�
    public float returnAngleSpeed;

    //����������
    public int bucketCapacity;

    //boolֵ��ָʾ�����Ƿ������ת״̬
    private bool rotateEnable;

    //��������ת���ͣ�0��ʾС�򵹳�֮ǰ����ת��1��ʾС�򵹳�֮�����ת
    private int rotateState;

    //������ת�����ܽǶȵļ���
    private float angleCount;

    //����С��ļ���
    private int enterBallNum;

    //�뿪С��ļ���
    private int exitBallNum;

    //�����ĳ�ʼ��ת
    private Vector3 originalEulerAngle;

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
        //��ʼʱ����������ת
        rotateEnable = false;

        //��ʼʱ���Ƕȼ���Ϊ0
        angleCount = 0;

        //��ʼʱ��������뿪С������Ϊ0
        enterBallNum = 0;
        exitBallNum = 0;

        //��¼��ʼŷ����
        originalEulerAngle = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //�������������ת״̬
        if (rotateEnable)
        {
            //���С����δ����
            if (rotateState == 0)
            {
                //��ת
                this.transform.Rotate(Vector3.forward, trippingAngleSpeed * Time.deltaTime);

                //�Ƕȼ�������
                angleCount += Mathf.Abs(trippingAngleSpeed * Time.deltaTime);
            }

            //���С���Ѿ�����
            if (rotateState == 1)
            {
                //��ת
                this.transform.Rotate(Vector3.forward, returnAngleSpeed * Time.deltaTime);

                //�Ƕȼ����ݼ�
                angleCount -= Mathf.Abs(returnAngleSpeed * Time.deltaTime);

                //����Ƕȴﵽ0
                if (angleCount <= 0)
                {
                    //�˳���ת״̬
                    rotateEnable = false;

                    //������תΪ��ʼ��ת
                    this.transform.eulerAngles = originalEulerAngle;

                    //���롢�뿪С������0
                    enterBallNum = 0;
                    exitBallNum = 0;

                    //�Ƕȼ�����0
                    angleCount = 0;
                }
            }
        }
    }

    //���ýű����������ʱ
    void OnDisable()
    {
    }

    //�������ײ�����ô�����ʱ
    void OnTriggerEnter2D(Collider2D coll)
    {
        //������������������С��
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //����С�����
            enterBallNum++;

            //�������С�����ﵽ��������
            if (enterBallNum == bucketCapacity)
            {
                //���ø�С�������ϵ��
                coll.attachedRigidbody.gravityScale = 1.7F;

                //����������ת״̬
                rotateEnable = true;

                //С�򵹳�֮ǰ����ת
                rotateState = 0;
            }
        }
    }

    //�������ײ���뿪�ô�����ʱ
    void OnTriggerExit2D(Collider2D coll)
    {
        //����뿪������������С��
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //�뿪С�����
            exitBallNum++;

            //����뿪С�����ﵽ��������
            if (exitBallNum == bucketCapacity)
            {
                //����������ת״̬
                rotateEnable = true;

                //С�򵹳�֮�����ת
                rotateState = 1;
            }
        }
    }
}

