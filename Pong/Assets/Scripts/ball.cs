using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField]
    float velocidade = 5f;
    [SerializeField]
    float lancarBola = 2f;

    float tempo = 0.0f;
    bool bolaJaFoiLancada = false;

    void Movimento()
    {
        GetComponent<Rigidbody2D>().velocity = velocidade * Random.insideUnitSphere;
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime; //tempo = tempo + Time.deltaTime;

        //if (bolaJaFoiLancada == false && tempo > lancarBola)
        //{
        //    Movimento();
        //    bolaJaFoiLancada = true;
        //}
        if (bolaJaFoiLancada == false)
        {
            if (tempo > lancarBola)
            {
                Movimento();
                bolaJaFoiLancada = true;
            }

        }
    }

}
