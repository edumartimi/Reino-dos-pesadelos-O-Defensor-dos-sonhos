using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cama : MonoBehaviour
{
    public bool encostando;
    private void OnTriggerStay2D(Collider2D collision)
    {
        encostando = true;  
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
        if (encostando)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
