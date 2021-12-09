using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour
{
  public GameObject gameoverText;
  public Text timeText;
  public Text recordText;

  private float surviveTime;
  private bool isGameOver;
  void Start()
  {
    surviveTime = 0;
    isGameOver = false;
  }
  void Update()
  {
    if (!isGameOver)
    {
      surviveTime += Time.deltaTime;
      timeText.text = "Time: " + (int)surviveTime;
    }
    else
    {
      if (Input.GetKeyDown(KeyCode.R))
      {
        SceneManager.LoadScene("SampleScene");
      }
    }
  }

  public void EndGame()
  {
    isGameOver = true;
    gameoverText.SetActive(true);

    float bestTime = PlayerPrefs.GetFloat("BestTime");
    if (surviveTime > bestTime)
    {
      bestTime = surviveTime;
      PlayerPrefs.SetFloat("BestTime", bestTime);
    }
    recordText.text = "Best Time:" + (int)bestTime;
  }
}
