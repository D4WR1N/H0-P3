using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desechos : MonoBehaviour
{
    public GameManager gm;
    private int daño = -1;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D personaje)
    {
        if (personaje.gameObject.CompareTag("Player"))
        {
            gm.vida(daño);
        }
    }
}
