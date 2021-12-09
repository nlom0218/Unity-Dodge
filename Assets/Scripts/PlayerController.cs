using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody playerRigidbody;
  public float speed = 8f;
  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody>();
  }
  void Update()
  {
    // 수평축과 수직축의 입력값을 감지하여 저장
    float xInput = Input.GetAxis("Horizontal");
    float yInput = Input.GetAxis("Vertical");

    // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
    float xSpeed = xInput * speed;
    float zSpeed = yInput * speed;

    // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
    Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

    // 리지드바디의 속도에 newVelocity 할당
    playerRigidbody.velocity = newVelocity;
  }
  public void Die()
  {
    gameObject.SetActive(false);
    GameManager gameManager = FindObjectOfType<GameManager>();
    gameManager.EndGame();
  }
}
