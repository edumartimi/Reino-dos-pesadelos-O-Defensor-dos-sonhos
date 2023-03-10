using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{

    private Rigidbody Fisica;
    private bool jump;
    public float JumpForce;
    // Start is called before the first frame update
    void Start()
    {
        Fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            jump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            jump = false;
        }
    }

    private void FixedUpdate()
    {
        if (jump) 
        {
            Fisica.AddRelativeForce(Vector3.up * JumpForce,ForceMode.Impulse);
        }
    }
}
