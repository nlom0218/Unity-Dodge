using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
  public GameObject bulletPrefab;
  public float spawnRataMin = 0.5f;
  public float spawnRateMax = 3f;

  private Transform target;
  private float spawnRate;
  private float timeAfterSpawn;
  void Start()
  {
    // 최근 생성 이후의 누적 시간을 0으로 초기화
    timeAfterSpawn = 0f;
    // 탄알 생성 간격을 spawnRateMinrhk spawnRateMax 사이에서 랜덤 지정
    spawnRate = Random.Range(spawnRataMin, spawnRateMax);
    // PlaterController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
    target = FindObjectOfType<PlayerController>().transform;
  }

  // Update is called once per frame
  void Update()
  {
    // timeAfterSpawn 갱신
    timeAfterSpawn += Time.deltaTime;

    // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
    if (timeAfterSpawn >= spawnRate)
    {
      timeAfterSpawn = 0f;

      // bulletPrefab의 복제본을 transform.position 위치와 transform.rotation 회전으로 생성
      GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
      bullet.transform.LookAt(target);

      // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
      spawnRate = Random.Range(spawnRataMin, spawnRateMax);
    }
  }
}
