using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loadMenu;
    
    public void LoadGames()
    {
        mainMenu.SetActive(false);
        loadMenu.SetActive(true);
    }

    public void backButton()
    {
        mainMenu.SetActive(true);
        loadMenu.SetActive(false);
    }
}
