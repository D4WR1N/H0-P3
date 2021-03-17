using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    public bool Disponible;
    private Animator anima;
    public GameManager gm;
    public Transform jugador;
    public Transform piso_2;
    public Transform piso_3;
    public Transform piso_4;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Disponible = false;
        anima = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D jugador)
    {
        if (jugador.gameObject.CompareTag("Player"))
        {
            Disponible = true;            
        }
    }
    private void OnTriggerExit2D(Collider2D jugador)
    {
        if (jugador.gameObject.CompareTag("Player"))
        {
            Disponible = false;
            anima.SetBool("EnUso", true);
        }
    }
    public void funcionando()
    {
        if(gm.piso == 1)
        {
            jugador.position = piso_2.position;
        }
        if (gm.piso == 2 && gm.codigo_1 == true)
        {
            jugador.position = piso_3.position;
        }
        if (gm.piso == 3 && gm.codigo_2 == true)
        {
            jugador.position = piso_4.position;
        }
    }
    void Update()
    {
        if(Disponible==true)
        {
            if(Input.GetButtonDown("Interactuar"))
            {
                anima.SetTrigger("Llamar");
                anima.SetBool("EnUso", false);
            }          
        }
    }
}
