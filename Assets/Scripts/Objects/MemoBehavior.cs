using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoBehavior : MonoBehaviour, IInteractiveObject
{
    [SerializeField] private GameObject memoImagePanel;
    [SerializeField] private float showImageDuration = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        if (memoImagePanel != null)
            memoImagePanel.SetActive(false);
    }

    public void OnInteract()
    {
        if (memoImagePanel != null && !memoImagePanel.activeInHierarchy)
        {
            memoImagePanel.SetActive(true);
            Invoke("HideImage", showImageDuration);
        }
    }

    private void HideImage()
    {
        memoImagePanel.SetActive(false);
    }
    
}
