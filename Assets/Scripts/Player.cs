using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public bool isGrounded;

    float dirX;

    public SpriteRenderer renderer;
    public Animator _animator;
    Rigidbody2D _rBody;

    private GameManager gameManager;

    void Awake()
    {
       _animator = GetComponent<Animator>();
       _rBody = GetComponent<Rigidbody2D>();
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
       dirX = Input.GetAxisRaw("Horizontal");

       Debug.Log(dirX);

       //transform.position += new Vector3(dirX, 0, 0) * speed * Time.deltaTime;


       if(dirX == -1)
       {
           renderer.flipX = true;
           _animator.SetBool("Running", true);
       }
       else if (dirX == 1)
       {
           renderer.flipX = false;
           _animator.SetBool("Running", true);
       }
       else
       {
           _animator.SetBool("Running", false);
       }

       if(Input.GetButtonDown("Jump") && isGrounded)
       {
           _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           _animator.SetBool("Jumping", true);
       }
    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirX * speed, _rBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");
            gameManager.DeadGoomba(collider.gameObject);
            gameManager.CuentaKillGoomba(collider.gameObject);
        }

        if(collider.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("Estas Muerto pringao");
            gameManager.DeathMario();
        }
        if(collider.gameObject.layer == 7)
        {
            Debug.Log("Una monedita bro");
            gameManager.ColeccionarMoneda(collider.gameObject);
            
            
        }
        if(collider.gameObject.layer == 8)
        {
            Debug.Log("Has ganao crack");
            gameManager.VictoriaMario();
        }
    }
} 
