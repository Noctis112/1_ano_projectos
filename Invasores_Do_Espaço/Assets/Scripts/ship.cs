using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    [SerializeField]
    GameObject fire;

    [SerializeField]
    Transform nozzle;

    [SerializeField]
    float velocidade = 5f;

    [SerializeField]
    int Vida = 3;


    float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        //0.5f para compensar o tamanho da nave
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 0.5f;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(fire, nozzle.position, nozzle.rotation);
        }

        Movimento();
    }

    void Movimento()
    {
        float hMov = Input.GetAxis("Horizontal");
        transform.position += hMov * velocidade * Vector3.right * Time.deltaTime;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vida -= 1;

        if(Vida == 0)
        Destroy(gameObject);
    }
}
