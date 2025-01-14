using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputProcessor : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputActionMap menuActionMap;
    private InputActionMap fieldActionMap;
    private InputAction unpauseAction;

    void Awake()
    {
        fieldActionMap = inputActionAsset.FindActionMap("field", true);
        menuActionMap = inputActionAsset.FindActionMap("menu", true);
        unpauseAction = menuActionMap.FindAction("Unpause", true);        
    }

    void OnEnable()
    {
        unpauseAction.performed += OnUnpauseInput;
    }

    void OnDisable()
    {
        if (menuActionMap.enabled)
            menuActionMap.Disable();
        unpauseAction.performed -= OnUnpauseInput;
    }

    public void OnUnpauseInput(InputAction.CallbackContext context)
    {
        Debug.Log("MenuInputProcessor - OnUnpause");
        GameManager.GetInstance().UnpauseGame();
    }

    public void OnContinue()
    {
        Debug.Log("OnUnpause");
        GameManager.GetInstance().UnpauseGame();
    }

    public void OnExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        Debug.Log("Exit Game!");
    }
    

    public void OnPause()
    {
        menuActionMap.Enable();
        fieldActionMap.Disable();
    }

    public void OnUnpause()
    {
        menuActionMap.Disable();
        fieldActionMap.Enable();
    }
}
