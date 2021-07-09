using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatInterface : MonoBehaviour
{
    public Text defeatInfo;

    private void OnEnable()
    {
        //�����ɫ����
        if (Myclass.currentGameState == GameState.ColorError)
        {
            //��ʾʧ����Ϣ
            defeatInfo.text = "Mismatched \n Colors";
        }
        //�����Ŀ����
        if (Myclass.currentGameState == GameState.NumError)
        {
            //��ʾʧ����Ϣ
            defeatInfo.text = "Too Many \n Marbles";
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //�������
    public void TryAgainButtonClick()
    {
        //���¼��عؿ�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
