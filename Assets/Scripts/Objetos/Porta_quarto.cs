using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta_quarto: MonoBehaviour
{
    public bool encostando;
    public int numero_cena;
    public bool entrounoquarto;
    private void OnTriggerStay2D(Collider2D collision)
    {
        encostando = true;  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        encostando = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (encostando)
        {
            if(Input.GetKeyDown(KeyCode.E) && numero_cena == 1)
            {
               entrounoquarto = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                SceneManager.LoadScene(numero_cena);  
            }  
        }
    }
}
