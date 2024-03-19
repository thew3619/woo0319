using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Vector3 moveDirection = Vector3.right; // 초기 이동 방향을 오른쪽으로 설정

    void Update()
    {
        // 키보드 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 입력에 따라 이동량 계산
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        if (movement.magnitude > 0.01f) // 키 입력이 있는 경우에만 이동 방향 업데이트
        {
            moveDirection = movement.normalized;
        }

        // 이동
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // 총알 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 총알을 생성하고 발사 방향으로 이동시킴
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<bullet>().SetDirection(moveDirection); // 총알의 방향 설정
    }
}
