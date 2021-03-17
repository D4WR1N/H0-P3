using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class controller : MonoBehaviour
{
    #region variables publicas
    public GameManager gm;
    [Header("stats")] 

   

    
    public bool face;

    //[Header("salto setup")]

    public Transform puntoSuelo;
    public Transform puntoObjeto;
    public LayerMask capaSuelo;
    public LayerMask CapaObstaculo;
    public bool contactoSuelo;
    public bool contactoObjeto;
    public float radio;
    public float saltar;
    public float velocidad;
    private float speedClamp = 4;
    [Header("VFX")]
   


    #endregion

    #region variables privadas
    private Rigidbody2D rb;
    private Animator anima;
    private int jumpCount;
    [Range(0, 1)]
    private int doubleJump; 
    private int state;
    #endregion




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Start()
    {
       
    }
    void vida()
    {
        if (gm.puntosDeVida < 0)
        {
            GameObject.Find("personaje").GetComponent<controller>().enabled = true;
            GameObject.Find("personaje").GetComponent<Animator>().enabled = true;
        }
        else if(gm. puntosDeVida >= 0)
        {
            GameObject.Find("personaje").GetComponent<controller>().enabled = false;
            GameObject.Find("personaje").GetComponent<Animator>().enabled = false;
        }    
    }
    public void Movimiento()
    {
        float velocidadX = Input.GetAxis("Horizontal");
        rb.position = new Vector2(rb.position.x + (velocidadX * velocidad) * Time.deltaTime, rb.position.y);
        anima.SetFloat("movilidadPersonaje", Mathf.Abs(velocidadX));
        anima.SetBool("Contacto Suelo", contactoSuelo);
        //anima.SetFloat("Velocidad Salto", rb.velocity.y);
        flip(velocidadX);
    }
    public void Escalar()
    {    
       float velocidadY = Input.GetAxis("Vertical");           
       {
          //rb.position = new Vector2(rb.position.x, (rb.position.y + velocidadY) * Time.deltaTime);
          transform.Translate(new Vector3(0,velocidadY * speedClamp * Time.deltaTime ,0));
           anima.SetFloat("escaladoPersonaje", Mathf.Abs(velocidadY));
          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (face)
                {
                    rb.AddForce(new Vector2(0.7f, 1) * saltar);
                }
                else
                {
                    rb.AddForce(new Vector2(-0.7f, 1) * saltar);
                }
            }
        }
    }

    void flip(float axi)
    {
        if (axi < 0 && !face || axi > 0 && face)
        {
            face = !face;
            Vector3 escalalocal = transform.localScale;
            escalalocal.x *= -1;
            transform.localScale = escalalocal;
        }
    }
    void groundedSystem()
    {
        contactoSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radio, capaSuelo);

    }
    void wallSystem()
    {
        contactoObjeto = Physics2D.OverlapCircle(puntoObjeto.position, radio, CapaObstaculo);
    }

    void Gravedad()
    {
        if (!contactoObjeto && contactoSuelo)
        {
            state = 0;
        } 
        else if (contactoSuelo && contactoObjeto)
        {
            state = 1;
        } 
        //else if (contactoObjeto && !contactoSuelo)
        //{
          //  state = 2;
        //} 
        else if (!contactoSuelo && !contactoObjeto)
        {
            state = 3;
        }

        switch (state)
        {
            case 0:
                rb.gravityScale = 7;
                Movimiento();
                velocidad = 10;
                saltar = 400;
                break;

            case 1:
                rb.gravityScale = 7;
                Movimiento();
                Escalar();
                velocidad = 10;
                saltar = 400;
                break;

            //case 2:
              //  rb.gravityScale = 0;
                //rb.velocity = Vector3.zero;
                //Movimiento();
                //Escalar();
                //velocidad = 0;
                //saltar = 1000;
                //break;

            case 3:
                rb.gravityScale = 7;
                Movimiento();
                velocidad = 15;
                saltar = 5;
                break;
        }
    }

    void salto()
    {
        if(Input.GetKeyDown(KeyCode.Space) && contactoSuelo)
        {
            rb.AddForce(Vector3.up * saltar);
        }
    }
    void dobleSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && contactoSuelo)
        {
            if (contactoSuelo)
            {
                rb.AddForce(Vector3.up * saltar);               
                jumpCount = 0;
            }       
            else
            {
                if(jumpCount == 1)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector3.up * saltar);
                }          
            }
            jumpCount++;
        }        
    }
  
    private void Update()
    {
        groundedSystem();
        wallSystem();
        Gravedad();
        //vida();
        switch(doubleJump)
        {
            case 0:
                salto();
               break;
            case 1:
               dobleSalto();
                break;
        }
        if (contactoObjeto == true)
        {
            //anima.SetBool("muro", true);
        }
        else
        {
            //anima.SetBool("muro", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(puntoSuelo.position, radio);
        Gizmos.DrawSphere(puntoObjeto.position, radio);
    }

    

}
