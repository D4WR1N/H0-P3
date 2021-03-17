using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigo_2 : MonoBehaviour
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
            gm.piso = 3;
            gm.codigo_2 = true;
            Destroy(gameObject);
        }
    }
}
