using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    //������ɫ����
    public int colorIndex;

    //����״̬��0Ϊ�գ�1Ϊ��ɫ�ԣ�-1Ϊ��ɫ��-2Ϊ����һ��
    public int basketState;

    //���ӵĶѵ��Ĳ�����
    public int pileIndex;

    //���������ӵ�С�����Ŀ
    private int exitBallNum;

    //����Ķ������ײ�����
    private PolygonCollider2D selfPolyCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        //��ʼʱ������Ϊ��
        basketState = 0;

        //��ʼʱ���뿪��С����Ϊ0
        exitBallNum = 0;

        //����Ķ������ײ�����
        selfPolyCollider2D = this.GetComponent<PolygonCollider2D>();

        //�����뿪С�����Ͷѵ��������ж϶������ײ������ļ��������״̬
        selfPolyCollider2D.enabled = (exitBallNum >= pileIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //С�����
   private void OnTriggerEnter2D(Collider2D coll)
    {
        //���С�����
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall") &&
            selfPolyCollider2D.enabled == true)
        {   //������ӿ�
            if (basketState == 0)
            {
                //��ȡĿ��С��physicsball���
                PhysicsBall tempPhysicsBall = coll.transform.GetComponent<PhysicsBall>();
                //�����ɫ��
                if (this.colorIndex == tempPhysicsBall.colorIndex)
                {
                    basketState = 1;
                    
                }
                else
                {
                basketState = -1;
                }
            }
            else
            {
                basketState = -2;
            }

            //��������״̬
            LevelController.Instance.GameStateRefresh();
        }
    }
    //����������ײ���뿪������ʱ��ִ�еĲ���
    void OnTriggerExit2D(Collider2D coll)
    {
        //����������ײ��������С��
        if (coll.gameObject.layer == LayerMask.NameToLayer("PhysicsBall"))
        {
            //�뿪С����+1
            exitBallNum++;

            //�����뿪С�����Ͷѵ��������ж϶������ײ������ļ��������״̬
            selfPolyCollider2D.enabled = (exitBallNum >= pileIndex);
        }
    }
}
