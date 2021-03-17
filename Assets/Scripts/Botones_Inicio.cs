using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Botones_Inicio : MonoBehaviour
{
    public void Niveluno()
    {
        SceneManager.LoadScene("nivel_1");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
