using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeManageObject : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> _list = new List<GameObject>();

    // Instance를 필요시마다 생성하는 경우는, 한번에 많은 Instance를 생성하려하면 렉이 걸리므로 ( CPU 부하 증가 ) 
    // 상황에 따라 object pooling ( object 정의 해놓은 상태에서 active/ inactive ) 를 하거나 Instance 생성하는 방법 중 선택해야함.
    // Instance --> 적은 메모리, 높은 cpu 부하. object pooling --> 높은 메모리, 적은 cpu 부하.

    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject instance = Instantiate(prefab);  // Instantiate<GameObject>(prefab);
            instance.name = $"복제품 {i}호";
            instance.transform.position = new Vector3(i*0.1f,0);

            _list.Add(instance);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            foreach(GameObject obj in _list)
            {
                Destroy(obj);
            }
            _list.Clear();
        }
    }

}
