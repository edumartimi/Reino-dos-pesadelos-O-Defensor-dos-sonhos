using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    private Animator animador;
    private Rigidbody2D fisica;
    private Transform posicaoplayer;
    public float JumpForce;
    public bool pulo;
    public float Velocidade;
    private bool podepular;
    public bool pausado;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chao") 
        {
            podepular = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
        fisica = GetComponent<Rigidbody2D>();
        posicaoplayer = GetComponent<Transform>();
        pausado = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && podepular)
        {
            podepular = false;
            pulo = true;  
        }
        int teste = Mathf.RoundToInt(fisica.velocity.x);

        animador.SetInteger("velocidade",teste) ;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
       
        fisica.velocity = new Vector2(Input.GetAxis("Horizontal") * Velocidade, fisica.velocity.y);

        if (Input.GetAxis("Horizontal") < 0 && posicaoplayer.localScale.x != -1) 
        {
            posicaoplayer.localScale = new Vector3(posicaoplayer.localScale.x * -1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0 && posicaoplayer.localScale.x != 1)
        {
            posicaoplayer.localScale = new Vector3(posicaoplayer.localScale.x * -1, 1, 1);
        }


        if (pulo)
        {
            fisica.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            pulo = false;
        }

    }

    private void pause_play() 
    {
        if (!pausado)
        {
            Time.timeScale = 0;
            pausado = true; 
        }
        else
        {
            Time.timeScale = 1;
            pausado = false;
        }
    }
}

