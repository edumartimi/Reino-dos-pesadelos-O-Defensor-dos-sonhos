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
    public bool delay_t_start;
    float carregamentojogo;
    public GameObject Carregando;


    private void Awake()
    {
        delay_t_start = true;
    }

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
        carregamentojogo = Time.deltaTime + carregamentojogo;
        if (delay_t_start) 
        {
            Carregando.active = true;
            if (carregamentojogo > 0.8f) 
            {
                delay_t_start = false;
                Carregando.active = false;
            }
        }

        pause = jogador.pausado;

        entrounoquarto = bd.entrounoquarto;

        if (SceneManager.GetActiveScene().buildIndex == 0 && entrounoquarto && !mudouspawn)
        {   
            jogador.transform.position = quarto.position;
            mudouspawn = true;
        }

    }
}
