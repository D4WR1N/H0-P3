using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigo_1 : MonoBehaviour
{
    public GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D jugador)
    {
        if (jugador.gameObject.CompareTag("Player"))
        {
            gm.piso = 2;
            gm.codigo_1 = true;
            Destroy(gameObject);
        }
    }
}
