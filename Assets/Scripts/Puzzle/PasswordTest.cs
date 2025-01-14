using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class PasswordTest : MonoBehaviour, IPuzzle
{
    public GameObject pass;
    public TMP_InputField inputField_PW;
    public Button Button_OK;

    private string password = "1212";

    public void CheckAnswer()
    {
        if(inputField_PW.text == password)
        {
            OnSuccess();
          
        }

        else
        {
            OnFail();        
        }
    }
    
    public void OnFail()
    {
        Debug.Log("Fail!");
    }

    public void OnSuccess()
    {
        Debug.Log("Correct!!");
    }
    
    public void CalcRemainingTiime(){} // 퍼즐 남은 시간
    public void Initialize(){}   // 퍼즐 초기화
    public void OnTimeOut(){}    // 퍼즐 시간 초과
    


    
}
