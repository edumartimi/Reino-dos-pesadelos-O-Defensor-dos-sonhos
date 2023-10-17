using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocou : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable") 
        {
            print("tocou");
        }
    }
}
