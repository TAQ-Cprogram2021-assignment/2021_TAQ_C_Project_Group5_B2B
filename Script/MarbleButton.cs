using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleButton : MonoBehaviour
{
    //��С�����ɫ����
    public int colorIndex;

    //�����϶�С��
    private GameObject tempDragBall;

    //���λ��
    private Vector3 currentMousePosition;

    //3D������ײ��Ϣ
    private RaycastHit hitInfo3D;

    //���߲���
    private int hitMask;

    // Start is called before the first frame update
    void Start()
    {
        //����������ײ����
        hitMask += 1 << LayerMask.NameToLayer("Entrance");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     //  ִ����갴��
     public void MarbleButtonDown()
    {
        //������굱ǰ����
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePosition.z = 0;

        //���ɶ�Ӧ�϶�С��
        tempDragBall = Instantiate(Resources.Load<GameObject>("Prefab/DragBall/" + colorIndex),
                                  currentMousePosition,
                                  Quaternion.identity) as GameObject;

    }

    //  ִ������ɿ�
    public void MarbleButtonUp()
    {
        //������ʱС��
        Destroy(tempDragBall);

        //����3D����
        Ray testRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //��������
       bool hitresult= Physics.Raycast(testRay, out hitInfo3D, Camera.main.farClipPlane,hitMask);

        //��������
        if (hitresult)
        {
            //���������С��
            Instantiate(Resources.Load<GameObject>("Prefab/PhysicsBall/" + colorIndex),
                        hitInfo3D.transform.position, Quaternion.identity);
           
        }
    }
}
