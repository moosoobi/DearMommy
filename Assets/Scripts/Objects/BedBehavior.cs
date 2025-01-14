using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedBehavior : MonoBehaviour, IInteractiveObject
{
    public int bedNumber; // 각 베드 오브젝트에 할당될 번호
    private BedSelectBehavior bedSelectBehavior;
    void Start()
    {
        bedSelectBehavior = GameObject.FindObjectOfType<BedSelectBehavior>();
    }

    public void OnInteract()
    {
        Debug.Log("bed"+bedNumber);
        // 상호작용 시 해당 베드 오브젝트가 선택된 것처럼 보이게 함
        GetComponent<SpriteRenderer>().color = Color.red;
        bedSelectBehavior.OnSelect(bedNumber);
    }
}
