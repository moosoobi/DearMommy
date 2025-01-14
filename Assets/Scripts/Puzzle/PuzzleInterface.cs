using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzle
{
   void CalcRemainingTiime(); // 퍼즐 남은 시간
   void Initialize();   // 퍼즐 초기화
   void OnTimeOut();    // 퍼즐 시간 초과
   void OnFail();       // 퍼즐 실패
   void OnSuccess();    // 퍼즐 성공
   void CheckAnswer();  // 퍼즐 정답 확인
}