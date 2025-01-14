using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedSelectBehavior : MonoBehaviour, IPuzzle
{
    public List<GameObject> bedObjects; // 퍼즐에 사용될 베드 오브젝트들
    public List<int> answer = new List<int>(); // 정답 리스트
    private List<int> selectedNumbers = new List<int>(); // 사용자가 선택한 번호들

    private int currentIndex = 0; // 현재 선택한 번호의 인덱스
    


    void Start()
    {
       
        Initialize();
    }
    public void OnSelect(int number)
    {
        // 현재 선택된 베드 오브젝트의 번호를 selectedNumbers 리스트에 추가
        
       
        selectedNumbers.Add(number);
        Debug.Log("Add number" + number);
        currentIndex++;

        CheckAnswer();
        
    }

    // 퍼즐 초기화
    public void Initialize()
    {
        currentIndex = 0;
        selectedNumbers.Clear();
         foreach (GameObject bedObject in bedObjects)
        {
            SpriteRenderer bedSpriteRenderer = bedObject.GetComponent<SpriteRenderer>();
            if (bedSpriteRenderer != null)
            {
                bedSpriteRenderer.color = Color.white;
            }
        }
    }

    // 퍼즐 정답 확인
    public void CheckAnswer()
    {
        if(selectedNumbers.Count<6)
        {
            bool isSuccess = true;
            for (int i = 0; i < selectedNumbers.Count; i++)
            {
                if (selectedNumbers[i] != answer[i])
                {
                    isSuccess = false;
                    break;
                }
            }
            if(!isSuccess)
            {
                OnFail();
            }
        }
        
        if(selectedNumbers.Count==6)
        {
            bool isSuccess = true;
            for (int i = 0; i < selectedNumbers.Count; i++)
            {
                if (selectedNumbers[i] != answer[i])
                {
                    isSuccess = false;
                    break;
                }
            }
            if(isSuccess)
            {
                OnSuccess();
            }
            else
            {
                OnFail();
            }
        }
        
    }

    // 퍼즐 성공 시 호출될 함수
    public void OnSuccess()
    {
        Debug.Log("Puzzle solved!");
        Initialize();
    }

    // 퍼즐 실패 시 호출될 함수
    public void OnFail()
    {
        Debug.Log("Puzzle failed!");
        Initialize(); // 퍼즐 초기화
    }

    public void CalcRemainingTiime(){} // 퍼즐 남은 시간
    public void OnTimeOut(){}
}
