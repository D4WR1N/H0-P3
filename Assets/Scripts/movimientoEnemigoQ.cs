using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoEnemigoQ : MonoBehaviour
{
    private float speed = 0.1f;
    private float maxSpeed = 2f;
    private int _Daño = -1;


    [Header("Options rays")]
    public float distanceRay;
    public LayerMask enemyMask;
    public Transform cañon;
    private Vector2 directionTarget = new Vector2(1, 0);
    private Rigidbody2D rbEnemy;
    public Rigidbody2D bala;
    private Vector2 move = new Vector2(1, 0);
    public bool siguiendo;
    public Transform juagdor;
    public GameManager gm;
    public Transform raySource;
    public float alcance = 5;
    public LayerMask hope;

    private Animator anima;

    void Start()
    {

        rbEnemy = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        anima = GetComponent<Animator>();
    }
    void Update()
    {
        //rbEnemy.velocity = (rbEnemy.velocity.x > maxSpeed) ? new Vector2(maxSpeed, rbEnemy.velocity.y) : rbEnemy.velocity;
        //rbEnemy.velocity = (rbEnemy.velocity.x < -maxSpeed) ? new Vector2(-maxSpeed, rbEnemy.velocity.y) : rbEnemy.velocity;       
        if (siguiendo)
        {
            FollowPlayer();
        }
        else
        {
            PatrolWay();
        }

    }
    void cazar()
    {
        if (Physics2D.OverlapCircle(raySource.position, alcance, hope))
        {
            siguiendo = false;
            anima.SetBool("alcance", true);

        }
        else
        {
            anima.SetBool("alcance", false);
        }

        //if (gm.puntosDeVida <= 0)
        //{
            //siguiendo = false;
            //anima.SetBool("alcance", false);

        //}
    }

    private void FixedUpdate()
    {
        if (!siguiendo)
        {
            RaycastHit2D hit = Physics2D.Raycast(raySource.position, new Vector2(1, 0), distanceRay, enemyMask);
            RaycastHit2D hit_less = Physics2D.Raycast(raySource.position, new Vector2(-1, 0), distanceRay, enemyMask);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {

                    siguiendo = true;
                    juagdor = hit.collider.transform;
                    Vector3 escalalocal = transform.localScale;
                    if (escalalocal.x == -1)
                    {
                        escalalocal.x *= -1;
                        transform.localScale = escalalocal;
                    }
                }
            }
            if (hit_less.collider != null)
            {
                if (hit_less.collider.tag == "Player")
                {

                    siguiendo = true;
                    juagdor = hit_less.collider.transform;
                    Vector3 escalalocal = transform.localScale;
                    if (escalalocal.x == 1)
                    {
                        escalalocal.x *= -1;
                        transform.localScale = escalalocal;
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay(new Vector2(raySource.position.x, raySource.position.y), new Vector2(juagdor.position.x, raySource.position.y)
            - new Vector2(raySource.position.x, raySource.position.y), Color.red);
            Vector3 escalalocal = transform.localScale;
            if (juagdor.position.x > raySource.position.x)
            {

                transform.localScale = escalalocal;
                if (escalalocal.x == -1)
                {
                    escalalocal.x *= -1;
                    transform.localScale = escalalocal;
                }
            }
            if (juagdor.position.x < raySource.position.x)
            {
                escalalocal.x *= -1;
                transform.localScale = escalalocal;
                if (escalalocal.x == 1)
                {
                    escalalocal.x *= -1;
                    transform.localScale = escalalocal;
                }
            }
        }
        cazar();

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.vida(_Daño);      
        }
        else
            move.x *= -1;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    void FollowPlayer()
    {
        distanceRay = 8;
        speed = 0.001f;
        //anima.SetFloat("velocidadEnemigo", Mathf.Abs(speed));
        int direction;
        if (juagdor.position.x > transform.position.x)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        rbEnemy.position += (move * speed * direction);
        float distance = Mathf.Abs(juagdor.position.x - transform.position.x);
        if (distance > distanceRay)
            siguiendo = false;
    }
    void PatrolWay()
    {
        distanceRay = 7;
        speed = 0.00001f;
        float velocidadX = speed;
        //anima.SetFloat("velocidadEnemigo", Mathf.Abs(speed));
        rbEnemy.position += move * speed;

        if (rbEnemy.velocity.x > maxSpeed)
        {
            rbEnemy.velocity = new Vector2(maxSpeed, rbEnemy.velocity.y);
        }
        else
        {
            rbEnemy.velocity = rbEnemy.velocity;
        }

        if (rbEnemy.velocity.x < -maxSpeed)
        {
            rbEnemy.velocity = new Vector2(-maxSpeed, rbEnemy.velocity.y);
        }
        else
        {
            rbEnemy.velocity = rbEnemy.velocity;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(raySource.position, new Vector3(1, 0, 0) * distanceRay);
        Gizmos.color = Color.black;
        Gizmos.DrawRay(raySource.position, new Vector3(-1, 0, 0) * distanceRay);
        Gizmos.DrawWireSphere(raySource.position, alcance);
    }
}
