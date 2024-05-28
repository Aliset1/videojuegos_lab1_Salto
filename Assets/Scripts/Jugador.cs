using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jugador : MonoBehaviour
{
    // Start is called before the first frame update
    public float fuerzaSalto;
    public int bandera=0;
    public GameManager gameManager;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bandera ==1)
        {
            animator.SetBool("estaSaltando", true);
            
                rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
                bandera = 0;
            
        }   
    }
    //detectar si el jugador choca con algo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
            bandera = 1;
        }
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
        }
    }
}
