using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionButton : MonoBehaviour
{
    public void PlayAgainButtonClick()
    {
        //重新加载关卡
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
