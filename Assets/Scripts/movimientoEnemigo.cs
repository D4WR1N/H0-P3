using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoEnemigo : MonoBehaviour
{
    private float speed;
    private float maxSpeed;
    private int _Daño = -1;


    [Header("Options rays")]
    public float distanceRay;
    public LayerMask enemyMask;
    public Transform mano;
    private Vector2 directionTarget = new Vector2(1, 0);
    private Rigidbody2D rbEnemy;
    //public Rigidbody2D bola;
    private Vector2 move = new Vector2(1, 0);
    public bool isFollow;
    public Transform playerFollow;
    public GameManager gm;
    public Transform raySource;
    public float alcance = 5;
    public LayerMask juga;
    public bool frente;
    public bool atras;

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
        if (isFollow)
        {
            FollowPlayer();
        }
        else
        {
            PatrolWay();
        }

    }
    private void FixedUpdate()
    {
        if (!isFollow)
        {
            RaycastHit2D hit = Physics2D.Raycast(raySource.position, new Vector2(1, 0), distanceRay, enemyMask);
            RaycastHit2D hit_less = Physics2D.Raycast(raySource.position, new Vector2(-1, 0), distanceRay, enemyMask);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                  
                    isFollow = true;
                    playerFollow = hit.collider.transform;
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
                   
                    isFollow = true;
                    playerFollow = hit_less.collider.transform;
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
            Debug.DrawRay(new Vector2(raySource.position.x, raySource.position.y), new Vector2(playerFollow.position.x, raySource.position.y)
            - new Vector2(raySource.position.x, raySource.position.y), Color.red);
            Vector3 escalalocal = transform.localScale;
            if (playerFollow.position.x > raySource.position.x)
            {
                transform.localScale = escalalocal;
                if (escalalocal.x == -1)
                {
                    escalalocal.x *= -1;
                    transform.localScale = escalalocal;
                }
            }
            if (playerFollow.position.x < raySource.position.x)
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
        distanceRay = 5;
        speed = 0.03f;
        //anima.SetFloat("velocidadEnemigo", Mathf.Abs(speed));
        int direction;
        if (playerFollow.position.x > transform.position.x)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        rbEnemy.position += (move * speed * direction);
        float distance = Mathf.Abs(playerFollow.position.x - transform.position.x);
        if (distance > distanceRay)
            isFollow = false;
    }
    void PatrolWay()
    {
        distanceRay = 5;
        speed = 0.0001f;
        float velocidadX = speed;
        anima.SetBool("siguiendo", false);
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
        Gizmos.color = Color.green;
        Gizmos.DrawRay(raySource.position, new Vector3(-1, 0, 0) * distanceRay);
        Gizmos.DrawWireSphere(raySource.position, alcance);

    }
}