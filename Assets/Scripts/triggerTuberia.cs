using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTuberia : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<Rigidbody2D>().simulated = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInChildren<Rigidbody2D>().simulated = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}