using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Mov : MonoBehaviour
{
    #region variables publicas
    public Transform parendt;
    public Transform childpersonaje;
    public GameObject startpoint;
    public GameObject endpoint;
    public float speedPlataform;

    #endregion
    #region variables privadas
    private bool isgoingrigth;

    #endregion

    void Start()
    {
        if (isgoingrigth)
        {
            transform.position = startpoint.transform.position;
        }
        else
        {
            transform.position = endpoint.transform.position;
        }
    }
    void Update()
    {
        EnemyMovement();

    }
    public void EnemyMovement()
    {
        if (!isgoingrigth)
        {
            transform.position = Vector3.MoveTowards(transform.position, endpoint.transform.position, speedPlataform * Time.deltaTime);
            if (transform.position == endpoint.transform.position)
            {
                isgoingrigth = true;

            }
        }
        if (isgoingrigth)
        {
            transform.position = Vector3.MoveTowards(transform.position, startpoint.transform.position, speedPlataform * Time.deltaTime);
            if (transform.position == startpoint.transform.position)
            {
                isgoingrigth = false;

            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            childpersonaje.SetParent(parendt);

        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            childpersonaje.SetParent(null);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawLine(startpoint.transform.position, endpoint.transform.position);
    }

}
