using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;

public class Thunder : MonoBehaviour
{
    public AudioSource thunder;
    int trovao;
    public Light2D raio;
    public Sprite raio1;
    public Sprite raio2;
    public Sprite raio3;
    bool sla;
    float tempo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trovao = Random.Range(1, 100);
        if (trovao >40 )
        {
            thunder.Play();
            sla = true;
        }
    }

    private void Update()
    {
        if (sla) 
        {
            tempo = Time.deltaTime + tempo;
            raio.intensity = 2;
            if (tempo > 0.1f) 
            {
                raio.intensity = 0;
                sla = false;
            }

        }
    }


}
