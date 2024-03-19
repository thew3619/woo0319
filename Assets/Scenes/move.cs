using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Vector3 moveDirection = Vector3.right; // �ʱ� �̵� ������ ���������� ����

    void Update()
    {
        // Ű���� �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �Է¿� ���� �̵��� ���
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        if (movement.magnitude > 0.01f) // Ű �Է��� �ִ� ��쿡�� �̵� ���� ������Ʈ
        {
            moveDirection = movement.normalized;
        }

        // �̵�
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // �Ѿ� �߻�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // �Ѿ��� �����ϰ� �߻� �������� �̵���Ŵ
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<bullet>().SetDirection(moveDirection); // �Ѿ��� ���� ����
    }
}
