using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    private Rigidbody2D fisica;
    private Transform posicaoplayer;
    public float JumpForce;
    public bool pulo;
    public float Velocidade;
    private bool podepular;


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
        fisica = GetComponent<Rigidbody2D>();
        posicaoplayer = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && podepular)
        {
            podepular = false;
            pulo = true;  
        }
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
}

