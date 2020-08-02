using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScript : MonoBehaviour
{
    // 5초마다 이벤트 구현
    //==============================================
    /*
     // 방법 1: time marking
     float currentTime = 0.0f;
     // Start()처럼 첫 프레임에 실행되나 Start()보다 먼저 실행됨. 1번 실행됨
     private void Awake() 
     {
         Debug.Log("Awake");
     }
     // 스크립트가 활성화 되고 첫 프레임에 실행
     private void Start()
     {
         Debug.Log("Start");
         currentTime = Time.time;
     }
     // 스크립트가 활성화 되어 있는 도중에 매 프레임마다 실행 (주기 조절 불가능)
     private void Update()
     {
         if ((Time.time - currentTime) > 5f) // 스크립트가 활성화 되고 나서 5초 후에 발동 조건
         {
             Something();
             currentTime = Time.time;
         }
     }
    */

    Coroutine myCoroutine;
    private void Start()
    {
        myCoroutine = StartCoroutine(testCoroutine()); // 코루틴 시작
        StopCoroutine(myCoroutine); // 코루틴 중지
    }
    // 방법 2: Coroutine 
    IEnumerator testCoroutine() // 로딩 화면에서 미니게임 구현하는 것도 이걸로 구현함.(로딩 자체는 느려짐)
     {
        yield return null;
        yield return new WaitForFixedUpdate(); // Fixed time 만큼 대기
        yield return new WaitForSeconds(1f); // 1초 대기 (게임 속도에 영향있음)
        yield return new WaitForSecondsRealtime(1f); //게임속도 영향없이 실제시간 1초 대기
     }


    void Something() { }
    // 스크립트가 활성화 되어 있는 도중 매 프레임이 그려진 후에 실행
    private void LateUpdate()
    {        
    }

    // 유니티에서 설정된 시간 마다 한번씩 실행 (메뉴 탭 Edit/ProjectSetting/Time/Fixed Timestep 에서 시간 설정 가능)
    private void FixedUpdate()
    {        
    }

    // 상태가 활성화로 변경되었을때
    // 스크립트 / 오브젝트가 활성화 되거나 생성되었을 때 발동
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    // 상태가 비활성화로 변경되었을때
    // 스크립트 / 오브젝트가 비활성화 되거나 삭제되었을때 발동
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // 스크립트가 적용된 오브젝트가 삭제되었을 때 발동
    // 오브젝트가 삭제되면 OnDisable() 먼저 실행 후 OnDestroy() 발동
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    // q.스크립트를 외부에서 활성 비활성 하는 방법?
}
