using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class irparajardim : MonoBehaviour
{
    public bool vamoimbora;
    public Image tela_escurecendo;
    float tempoescurecendo;
    int contador;
    private void OnTriggerEnter(Collider other)
    {
        vamoimbora = true;
    }

    private void Update()
    {
        if (vamoimbora && Input.GetKeyDown(KeyCode.E)) 
        {
            contador++;
            if (contador > 1)
            {
                SceneManager.LoadScene("Jardim");
            }

        }
    }


}
