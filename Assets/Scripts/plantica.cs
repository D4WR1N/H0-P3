using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class plantica : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D jugador)
    {
        if (jugador.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu_Inicio");
        }
    }
}
