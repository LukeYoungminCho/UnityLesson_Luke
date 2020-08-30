using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoringText : Text
{
    public int value
    {
        get
        {
            return destValue;
        }
        set
        {
            destValue = value;
            if (curRoutine != null)
            {
                StopCoroutine(curRoutine);
                curRoutine = null;
            }
            curRoutine = StartCoroutine(Scoring(0.1f));
        }
    }
    private Coroutine curRoutine;
    private int curValue; // 현재 벨류
    private int destValue; // 목표 벨류

    IEnumerator Scoring(float time) // 1을 넣으면 1초에 걸쳐서 목표 벨류로 변경한다.
    {
        // 속력(증가치) = 거리(목표와의 차이) / 시간
        // addValue = (destValue - curValue) / time
        int addValue = (int)((destValue - curValue) / time);

        while (curValue < destValue)
        {
            curValue += (int)(addValue * Time.deltaTime);
            //destValue가 100, 증가 값이 10인데, curValue = 95 이면 105가 되어서 버그가 나기 때문에
            //해당 경우를 예외처리해준다.
            if (curValue > destValue)
                curValue = destValue;

            this.text = curValue.ToString();

            yield return null;
        }
    }
}
