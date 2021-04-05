using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] invasores;

    [SerializeField]
    GameObject[] invasoresIndestrutiveis;

    [SerializeField]
    int nInvasores = 7;

    float xMinimo = -3f;
    float yMinimo = 0.5f;
    float xInc = 1f;
    float yInc = 0.5f;

    [SerializeField]
    float probDeIndestrutivel = 0.15f;

    float minX, maxX;

    bool mov = true;

    [SerializeField]
    float velocidade = 0.005f;

    bool vMov = false;

    void Awake()
    {
        //código para "pega neste objeto e move-o do sítio.
        // eu pego no objeto dando ao unity um template do objeto e

        float y = yMinimo;

        for (int line = 0; line < invasores.Length; line++)
        {
            float x = xMinimo;
            for (int i = 1; i <= nInvasores; i++)
            {
                if (Random.value <= probDeIndestrutivel)
                {
                    GameObject newInvader = Instantiate(invasoresIndestrutiveis[line], transform);
                    newInvader.transform.position = new Vector3(x, y, 0f);
                }
                else
                {
                    GameObject newInvader = Instantiate(invasores[line], transform);
                    newInvader.transform.position = new Vector3(x, y, 0f);
                }
                x += xInc;
            }
            y += yInc;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 3.3F;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - 3.3F;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;


        if (mov == true)
        {
            transform.position += velocidade * Vector3.right;

            if (position.x == maxX && vMov == false)
            {
                if (position.y <= -2)
                    vMov = true;
                else
                    transform.position += 0.2f * Vector3.down; //(0,1,0)
            }
            if(position.x ==maxX)
                mov = false;
        }
        else
        {
            transform.position -= velocidade * Vector3.right;

            if (position.x == minX && vMov == false)
            {
                if (position.y <= -2)
                    vMov = true;
                else
                    transform.position += 0.2f * Vector3.down;
            }
            if(position.x == minX)
                mov = true;
        }
    }
}
