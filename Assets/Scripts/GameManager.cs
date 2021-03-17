using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [Range(0,3)]
    public int puntosDeVida;
    public int piso;
    public bool codigo_1;
    public bool codigo_2;

    private void Start()
    {
        puntosDeVida = 3;
        codigo_1 = false;
        codigo_2 = false;
    }
    public void vida(int pdv)
    {
        puntosDeVida += pdv;
    }
}
