using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public bool enUso;
    void Start()
    {
        enUso = false;
    }
    private void OnCollisionStay2D(Collision2D jugador)
    {
        if (jugador.gameObject.CompareTag("Player"))
        {
            enUso = true;
        }
    }
    private void OnCollisionExit2D(Collision2D jugador)
    {
        if (jugador.gameObject.CompareTag("Player"))
        {
            enUso = false;          
        }
    }
    void Update()
    {
        if(enUso==true)
        {

        }
    }
}
