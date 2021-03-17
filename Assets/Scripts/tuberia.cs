using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuberia : MonoBehaviour
{
    private GameManager gm;
    private int daño = -1;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.vida(daño);
            Destroy(gameObject);
        }
        else
        {
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(this);
        }
    }
}