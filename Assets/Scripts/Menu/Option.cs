using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    
    public void Options()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void backButton()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
}
