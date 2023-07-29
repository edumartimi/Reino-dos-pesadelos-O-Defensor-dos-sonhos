using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    private float lenght;
    private float StartPos;

    private Transform cam;

    public float ParallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = cam.transform.position.x * ParallaxEffect;

        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);
    }
}
