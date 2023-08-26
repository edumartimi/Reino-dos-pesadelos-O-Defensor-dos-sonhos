using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class anel : MonoBehaviour
{
    public Light2D luz;
    public bool visivel;
    public float tempo;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "luz") 
        {
            visivel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        visivel = false;
    }

    private void Start()
    {
        luz.enabled = false;
        tempo = 12;
    }

    private void Update()
    {
        if (visivel)
        {
            luz.enabled = true;
            tempo = tempo + Time.deltaTime;
            if (tempo < 15)
            {
                luz.intensity = tempo;
            }
            else
            {
                tempo = 12;
            }
        }
        else 
        {
            luz.enabled = false;
        }
    }
}
