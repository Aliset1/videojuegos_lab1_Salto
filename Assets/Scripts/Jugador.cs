using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jugador : MonoBehaviour
{
    // Start is called before the first frame update
    public float fuerzaSalto;
    public GameManager gameManager;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public bool bandera = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bandera)
        {
            animator.SetBool("estaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
            // Después de saltar, el personaje no puede saltar nuevamente    
            bandera = false; 
        }   
    }
    //detectar si el jugador choca con algo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
            bandera = true;
        }
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
        }
    }
}
