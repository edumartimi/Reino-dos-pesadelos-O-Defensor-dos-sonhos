using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bd : MonoBehaviour
{

    public static bool entrounoquarto;

    public Porta_quarto porta;
    public GameManager gerenciador;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (porta.entrounoquarto) 
        {
            entrounoquarto = true;
        }
        
    }
}
