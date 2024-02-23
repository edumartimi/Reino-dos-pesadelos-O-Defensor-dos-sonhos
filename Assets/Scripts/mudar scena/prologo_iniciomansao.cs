using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class prologo_iniciomansao : MonoBehaviour
{
    public bool mudar_scena;
    public Image tela_escurecendo;
    float tempoescurecendo;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (mudar_scena) 
        {
            tempoescurecendo = Time.deltaTime + tempoescurecendo;
            tela_escurecendo.color = new Vector4(0, 0, 0, tempoescurecendo);

            if (tempoescurecendo > 2) 
            {
                SceneManager.LoadScene("Entrada Mansão");
            }
        }

    }
}
