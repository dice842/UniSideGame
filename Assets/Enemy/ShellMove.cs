using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMove : MonoBehaviour
{
    float moveSpeed = 5f;
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D.Destroy(this.gameObject);
        if (collision.gameObject.tag == "Player")
        {
            PlayerController controller = collision.GetComponent<PlayerController>();
            controller.Dead();
        }
    }
}
