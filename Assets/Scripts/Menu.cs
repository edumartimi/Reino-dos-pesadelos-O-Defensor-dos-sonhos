using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public DialogueSystemWithImages sistema_jogo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void iniciar_jogo() 
    {
        menu.SetActive(false);
        sistema_jogo.enabled = true;
    }
}
