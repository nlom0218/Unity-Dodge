using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody playerRigidbody;
  public float speed = 8f;
  void Start()
  {

  }
  void Update()
  {

  }
  public void Die()
  {
    gameObject.SetActive(false);



  }
}
