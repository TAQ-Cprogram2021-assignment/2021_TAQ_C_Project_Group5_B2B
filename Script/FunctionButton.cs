using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionButton : MonoBehaviour
{
    public void PlayAgainButtonClick()
    {
        //���¼��عؿ�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
