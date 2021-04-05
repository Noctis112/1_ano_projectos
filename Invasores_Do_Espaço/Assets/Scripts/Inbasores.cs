using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inbasores : MonoBehaviour
{
    [SerializeField]
    GameObject fire;

    [SerializeField]
    float cadencia = 1.5f;

    [SerializeField]
    int VidaIn = 10;

    float tempoQuePassou = 0f;

    float probTiro = 0.15f;

    void Update()
    {
        tempoQuePassou += Time.deltaTime;
        
        if(tag == "Destrutivel")
        {
            if (tempoQuePassou >= cadencia)
            {
                if (Random.value <= probTiro)
                    Instantiate(fire, transform.position, transform.rotation);

                tempoQuePassou = 0f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Indestrutivel")
        {
            if (collision.gameObject.tag == "Friendly Fire")
            {
                VidaIn -= 1;
                if (VidaIn == 0)
                    Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
