using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piso_1 : MonoBehaviour
{
    public GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerStay2D(Collider2D personaje)
    {
        if (personaje.gameObject.CompareTag("Player"))
        {
            gm.piso = 1;
        }
    }
}
