using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public InteractiveObject portão;
    public GameObject MainCamera;
    public GameObject Inventario;
    public bool interacao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interacao = portão.anelscript;
        if (interacao) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                MainCamera.active =false;
                Inventario.active = true;
                Cursor.visible = true;
            }
        
        }
    }
}
