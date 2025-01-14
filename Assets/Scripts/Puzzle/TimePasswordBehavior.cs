using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;
using System.Collections.Generic;

public class TimePasswordBehavior : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    //public TMP_Text gameOverText;
    float time;
    int min,sec;
    bool isCountingTime;

    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] TimelineAsset startTimeline;
    [SerializeField] TimelineAsset gameOverTimeline;

    [SerializeField] List<string> startDialogList;
    [SerializeField] GameObject startDialogPanel;
    private DialogManager dialogManager;

    void Awake()
    {
        dialogManager = FindAnyObjectByType<DialogManager>();
    }

    void Start()
    {
        timeText.gameObject.SetActive(false);
        playableDirector.Play(startTimeline);
        isCountingTime = false;
    }

    public void ShowStartDialog()
    {
        dialogManager.ShowDialog(startDialogList, startDialogPanel, StartCounting);
    }

    private void StartCounting()
    {
        timeText.gameObject.SetActive(true);
        timeText.text="00:30";
        time = 30f;
        isCountingTime = true;
    }

    void Update()
    {
        if (isCountingTime)
        {
            time -= Time.deltaTime;

            min = (int)time / 60;
            sec = ((int)time - min * 60) % 60;

            timeText.text = string.Format("{0:00}", min) + " : " + string.Format("{0:00}", sec);

            if (time <= 0f)
            {
                isCountingTime = false;
                OnTimeOut();
            }
        }
    }

    public void OnTimeOut()
    {
        playableDirector.Play(gameOverTimeline);
    }

    public void Restart()
    {
        GameManager.GetInstance().LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
