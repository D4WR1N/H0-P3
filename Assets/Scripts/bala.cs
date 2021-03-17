using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
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
            Destroy(gameObject);
        }
    }
}