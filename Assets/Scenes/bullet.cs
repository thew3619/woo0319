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

        // ȭ�� ������ ������ �� �ı�
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject,butdelt);
        }
    }

    // ���� ���� �Լ�
    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }
}
