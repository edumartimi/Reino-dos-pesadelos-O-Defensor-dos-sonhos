using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public InteractiveObject portão;
    public GameObject MainCamera;
    public GameObject Inventario;
    public bool interacao;
    public Animator CamAnimator;
    public bool camera2d;
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
                changecam();
                CamAnimator.SetTrigger("olhar");
            }
        
        }
    }

   public void changecam()
    {
        if (MainCamera.active)
        {
            MainCamera.active = false;
            Inventario.active = true;
            Cursor.visible = true;
            camera2d = false;
        }
        else 
        {
            camera2d = true;
            MainCamera.active = true;
            Inventario.active = false;
            Cursor.visible = false;
        }
    }

}
