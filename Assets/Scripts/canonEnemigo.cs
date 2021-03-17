using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonEnemigo : MonoBehaviour
{
    public Transform apuntar;
    private float spee = 50;


    void Start()
    {
        apuntar = GameObject.Find("corazon").transform;
    }
    void disparo()
    {
        Vector2 direcion = apuntar.position - transform.position;
        float angulo = Mathf.Atan2(direcion.y, direcion.x) * Mathf.Rad2Deg;
        Quaternion rotacion = Quaternion.AngleAxis(angulo, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, spee * Time.deltaTime);


    }
    void Update()
    {
        disparo();
    }
}
