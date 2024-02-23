using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Animator portao;
    public CameraController Cameras;
    public AutoActiveObject anel;
    public bool ativou;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ativou = anel.leu_a_mensagem;

        if (Cameras.camera2d && ativou)
        {
            portao.SetTrigger("portao");
        }
    }
}
