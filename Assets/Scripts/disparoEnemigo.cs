using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoEnemigo : MonoBehaviour
{
    
    public Rigidbody2D bala;

    public Transform cañon;          

    private string m_FireButton;               
    public float fuerza;
    private void Update()
    {

    }
    private void Fire()
    {
        Rigidbody2D
         shellInstance =
        Instantiate(bala, cañon.position, cañon.rotation) as Rigidbody2D;
        shellInstance.velocity = fuerza * cañon.right;
    }
}

