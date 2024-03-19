using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5f;
    public float butdelt = 3.0f;
    private Vector3 moveDirection;

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 화면 밖으로 나갔을 때 파괴
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject,butdelt);
        }
    }

    // 방향 설정 함수
    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }
}
