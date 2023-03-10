using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escadas : MonoBehaviour
{
    private bool encostando;
    public Transform Andardecima;
    private GameObject personagem;
    private void OnTriggerStay2D(Collider2D collision)
    {
        encostando = true;
        personagem = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        encostando = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (encostando && Input.GetKeyDown(KeyCode.UpArrow)) 
        {

            personagem.GetComponent<SpriteRenderer>().enabled = false;
            personagem.transform.position =  Andardecima.position;
            personagem.GetComponent<SpriteRenderer>().enabled = true;

        }
    }
}
