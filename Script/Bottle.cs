using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    //ƿ�ڳ���ĽǶ�����
    public float[] angleArray;

    //��ǰƿ�ڳ���ĽǶ��ڽǶ������е�����
    private int currentAngleIndex;

    //2D���ߵ���ײ��Ϣ
    private RaycastHit2D hitInfo2D;

    //������ײ�Ĳ���
    private int hitMask;

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
        //��ʼʱ���Ƕ�����Ϊ0
        currentAngleIndex = 0;

        //������ײ�Ĳ���
        hitMask += 1 << LayerMask.NameToLayer("Bottle");
    }

    // Update is called once per frame
    void Update()
    {
        //�����Ϸ����Playing״̬��������갴��
        if (Myclass.currentGameState == GameState.Playing && Input.GetMouseButtonDown(0))
        {
            //������λ��
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //������λ����ƿ�ӵ���ײ��ķ�Χ֮��
            if (this.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
            {
                //����2D����
                hitInfo2D = Physics2D.Raycast(mousePosition, Vector3.forward, Camera.main.farClipPlane, hitMask);

                //���������ײ����ƿ��
                if (hitInfo2D)
                {
                    //�Ƕ���������
                    currentAngleIndex = (currentAngleIndex + 1) % angleArray.Length;

                    //�ı�ƿ�ӳ���
                    this.transform.eulerAngles = Vector3.forward * angleArray[currentAngleIndex];
                }
            }
        }
    }

    //���ýű����������ʱ
    void OnDisable()
    {
    }
}
