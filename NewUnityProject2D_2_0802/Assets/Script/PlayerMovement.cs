using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }
        // 대각선으로 이동시에도 같은 길이만큼 이동하도록 설정
        dir = dir.normalized;

        // transform 은  Vector 3 라서 캐스팅이 필요함
        // Time.deltaTime 은 프레임 사이의 시간을 반환해줌.이걸 안곱해주면 FPS에 따라 연산량이 많아져서 이동속도가 빨라짐.
         Vector3 precPosition = transform.position + (Vector3)(dir * moveSpeed * Time.deltaTime); 

        // Validation 체크
        if(precPosition.x > 8f)
        {
            precPosition = new Vector3(7.5f, precPosition.y, precPosition.z);
        }
        else if(precPosition.x < -8f)
        {
            precPosition = new Vector3(-7.5f, precPosition.y, precPosition.z);
        }

        if (precPosition.y > 4f)
        {
            precPosition = new Vector3(precPosition.x, 3.5f, precPosition.z);
        }
        else if (precPosition.y < -4f)
        {
            precPosition = new Vector3(precPosition.x, -3.5f, precPosition.z);
        }

        transform.position = precPosition;

    }
}
