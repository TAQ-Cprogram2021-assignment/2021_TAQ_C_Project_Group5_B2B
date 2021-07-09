using UnityEngine;
using System.Collections;

public class ColorMixer : MonoBehaviour
{
    //����û����������С��
    private GameObject firstBall;
    private GameObject secondBall;

    //����С�����ɫ����
    private int firstColorIndex;
    private int secondColorIndex;

    //���֮�����ɫ����
    private int mixedColorIndex;

    //�����С�������
    private int enterBallNum;

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
        //��ʼʱ������С����Ϊ0
        enterBallNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //���ýű����������ʱ
    void OnDisable()
    {
    }

    //�������ײ����������Ĵ�����ʱ
    void OnTriggerEnter2D(Collider2D coll)
    {
        //������������������С��
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //С�����
            enterBallNum++;

            //���������ǵ�һ��С��
            if (enterBallNum == 1)
            {
                //�ٶ�Ϊ0
                coll.attachedRigidbody.velocity = Vector2.zero;

                //����ϵ��Ϊ0
                coll.attachedRigidbody.gravityScale = 0;

                //λ������
                coll.transform.position = this.transform.position;

                //��¼��С��
                firstBall = coll.gameObject;

                //��ȡ��С�����ɫ����
                firstColorIndex = firstBall.GetComponent<PhysicsBall>().colorIndex;
            }

            //���������ǵڶ���С��
            if (enterBallNum == 2)
            {
                //�ٶ�Ϊ0
                coll.attachedRigidbody.velocity = Vector2.zero;

                //����ϵ��Ϊ0
                coll.attachedRigidbody.gravityScale = 0;

                //λ������
                coll.transform.position = this.transform.position;

                //��¼��С��
                secondBall = coll.gameObject;

                //��ȡ��С�����ɫ����
                secondColorIndex = secondBall.GetComponent<PhysicsBall>().colorIndex;

                //������֮���С�����ɫ����
                mixedColorIndex = Myclass.ColorMixingTable[firstColorIndex, secondColorIndex];

                //���ٵڶ���С��
                Destroy(secondBall);

                //�޸ĵ�һ��С�����ɫ����
                firstBall.GetComponent<PhysicsBall>().colorIndex = mixedColorIndex;

                //�޸ĵ�һ��С���ͼƬ��ɫ
                firstBall.GetComponent<SpriteRenderer>().color = Resources.Load<SpriteRenderer>("Prefab/PhysicsBall/" + mixedColorIndex).color;

                //��һ��С������ϵ���ָ�
                firstBall.GetComponent<Rigidbody2D>().gravityScale = 1;

                //����С�������0
                enterBallNum = 0;
            }
        }
    }
}
