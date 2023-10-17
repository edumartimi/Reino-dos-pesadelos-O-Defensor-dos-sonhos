using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    private Animator animador;
    private Rigidbody2D fisica;
    private Transform posicaoplayer;
    public float Velocidade;
    public bool pausado;
    public GameObject pressE;
    public bool colidindo;
    private bool pegar_lanterna;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lanterna") 
        {
            pegar_lanterna = true;
        }
        if (collision.gameObject.tag == "carro" && pegar_lanterna)
        {
            animador.SetTrigger("lanterna");
            animador.SetTrigger("abaixa");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Press")
        {
            pressE.SetActive(true);
            colidindo = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (pressE.active) 
        {
            pressE.SetActive(false);
        }
    }

    void Start()
    {
       animador = GetComponent<Animator>();
        fisica = GetComponent<Rigidbody2D>();
        posicaoplayer = GetComponent<Transform>();
        pausado = false;
        colidindo = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_play();
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

