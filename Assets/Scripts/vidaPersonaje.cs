using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaPersonaje : MonoBehaviour
{
    public GameManager gm;
    [Range(0, 3)]
    public int vida;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        vida = gm.puntosDeVida;
    }
}
