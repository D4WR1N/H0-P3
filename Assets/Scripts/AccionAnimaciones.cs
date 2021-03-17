using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionAnimaciones : MonoBehaviour
{private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {


            anim.SetBool("Play", true);


        }

      

    }

   
}
