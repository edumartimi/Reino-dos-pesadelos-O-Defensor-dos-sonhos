using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bd porta;
    public Player2D jogador;
    bool pause;
    public Transform quarto;

    bool entrounoquarto;
    bool mudouspawn = false;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            quarto = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
        }
        Cursor.visible = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        pause = jogador.pausado;

        entrounoquarto = bd.entrounoquarto;

        if (SceneManager.GetActiveScene().buildIndex == 0 && entrounoquarto && !mudouspawn)
        {   
            jogador.transform.position = quarto.position;
            mudouspawn = true;
        }

    }
}
