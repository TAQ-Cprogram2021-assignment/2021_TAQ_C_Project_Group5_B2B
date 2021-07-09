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
        //如果颜色错误
        if (Myclass.currentGameState == GameState.ColorError)
        {
            //显示失败信息
            defeatInfo.text = "Mismatched \n Colors";
        }
        //如果数目错误
        if (Myclass.currentGameState == GameState.NumError)
        {
            //显示失败信息
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

    //点重玩后
    public void TryAgainButtonClick()
    {
        //重新加载关卡
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
