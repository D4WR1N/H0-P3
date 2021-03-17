using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camarografo : MonoBehaviour
{
    public Transform jugador;
    private Vector3 posicion;
    void Update()
    {       
       transform.position = new Vector3(jugador.position.x + posicion.x, jugador.position.y + posicion.y, -20);   
        
    }
}
