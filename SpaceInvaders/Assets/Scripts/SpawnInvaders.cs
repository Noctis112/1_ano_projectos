using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{
    [SerializeField]
    GameObject InvasorA;

    [SerializeField]
    GameObject InvasorB;

    [SerializeField]
    GameObject InvasorC;

    [SerializeField]
    int nInvasores = 7;

    [SerializeField]
    float xMin = -3f;

    [SerializeField]
    float yMin =  0f;
    
    void Awake()
    {
        //float x = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //    GameObject newInvader = Instantiate(InvasorA, transform);
        //    newInvader.transform.position = new Vector3(x, -1.5f, 0f);
        //    x += 1f;
        //}

        //float x2 = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //    GameObject newInvader = Instantiate(InvasorA, transform);
        //    newInvader.transform.position = new Vector3(x2, -0.5f, 0f);
        //    x2 += 1f;
        //}
        //float x3 = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //    GameObject newInvader = Instantiate(InvasorB, transform);
        //    newInvader.transform.position = new Vector3(x3, 0.5f, 0f);
        //    x3 += 1f;
        //}
        //float x5 = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //    GameObject newInvader = Instantiate(InvasorB, transform);
        //    newInvader.transform.position = new Vector3(x5, 1.5f, 0f);
        //    x5 += 1f;
        //}
        //float x4 = xMin;
        //for (int i = 1; i <= nInvasores; i++)
        //{
        //    GameObject newInvader = Instantiate(InvasorC, transform);
        //    newInvader.transform.position = new Vector3(x4, 2.5f, 0f);
        //    x4 += 1f;
        //}
        
        float x = xMin;
        float y = yMin;
        for (int i = 1; i <= 5; i++)
        {
            for(int j = 1; j <= nInvasores; j++)
            {
                if (j == 1)
                    x = xMin;

                if(i == 1)
                    Invasores(InvasorA, 0);
                if (i == 2)
                    Invasores(InvasorA, 0.5f);
                if (i == 3)
                    Invasores(InvasorB, 1f);
                if (i == 4)
                    Invasores(InvasorB, 1.5f);
                if (i == 5)
                    Invasores(InvasorC, 2f);
            }
        }

        void Invasores(GameObject Invasor, float p)
        {
            
            y = yMin + p;
            GameObject newInvader = Instantiate(Invasor, transform);
            newInvader.transform.position = new Vector3(x, y, 0f);
            x += 1f;
        }
         
        

    }

}

