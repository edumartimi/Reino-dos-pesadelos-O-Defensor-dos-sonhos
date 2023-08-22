using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologo_iniciomansao : MonoBehaviour
{
    public bool mudar_scena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mudar_scena) 
        {
            SceneManager.LoadScene("Entrada Mansão");
        }
    }
}
