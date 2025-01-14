using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.GetInstance().LoadScene("인트로");
    }
}
