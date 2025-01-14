using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using System.Collections.Generic;

public class PCBehavior : MonoBehaviour, IPuzzle, IInteractiveObject
{
    public static bool isAlreadyVisited = false;

    [SerializeField] private float SuccessToLoadSceneDelay = 0.5f;
    [SerializeField] private string password;
    [SerializeField] private TMPro.TMP_InputField passwordInputField;
    [SerializeField] private float showImageDuration = 2.0f;

    public GameObject passwordHint;
    public GameObject underdoor;
    public GameObject message;

    [SerializeField] private AudioSource doorOpenSound;
    [SerializeField] private AudioSource monsterOpenDoorSound;
    
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private GameObject monsterDialogPanel;
    [SerializeField] private GameObject defaultDialogPanel;
    [SerializeField] private List<string> startDialogList;

    private DialogManager dialogManager;

    //public TextMeshProUGUI engtokor;

    void Start()
    {
        underdoor.gameObject.SetActive(false);
        message.gameObject.SetActive(false);

        dialogManager = FindAnyObjectByType<DialogManager>();
        if (!isAlreadyVisited)
            dialogManager.ShowDialog(startDialogList, defaultDialogPanel, null);

        isAlreadyVisited = true;
    }

    public void OnInteract()
    {
        Debug.Log("PC ON!");
        passwordInputField.onSubmit.AddListener(delegate { CheckAnswer(); });
        passwordInputField.onDeselect.AddListener(delegate { passwordInputField.gameObject.SetActive(false); });
       

        if (!passwordInputField.gameObject.activeInHierarchy)
        {
            passwordHint.gameObject.SetActive(true);
            passwordInputField.gameObject.SetActive(true);
            passwordInputField.Select();
            passwordInputField.ActivateInputField();
            Initialize();
        }
    }

    public void Initialize()
    {
        passwordInputField.text = "";
    }

    public void CheckAnswer()
    {
        Debug.Log("PCBehavior - CheckAnswer");
        if (password.CompareTo(passwordInputField.text) == 0) // 비밀번호가 일치하는 경우
            OnSuccess();
        else
            OnFail();
    }

    public void OnFail()
    {
        Debug.Log("PCBehavior - OnFail");
        passwordInputField.gameObject.SetActive(false);
        passwordHint.gameObject.SetActive(false);
    }

    public void OnSuccess()
    {
        Debug.Log("PCBehavior - OnSuccess");
        doorOpenSound.Play();
        passwordInputField.gameObject.SetActive(false);
        passwordHint.gameObject.SetActive(false);

        underdoor.gameObject.SetActive(true); 
        message.gameObject.SetActive(true);
       // monster.gameObject.SetActive(true);
        Invoke("HideImage", showImageDuration);

        monsterOpenDoorSound.Play();
        dialogManager.ShowDialogNoText(monsterDialogPanel, playableDirector.Play);
        GameManager.GetInstance().isPrincipleRoomEventSeen = true;
    }

    private void HideImage()
    {
        message.SetActive(false);
    }

    public void OnTimeOut()
    {
    }

    public void CalcRemainingTiime()
    {
    }
}
