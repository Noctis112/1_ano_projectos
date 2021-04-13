using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Lander : MonoBehaviour
{
    [SerializeField]
    float vel = 150f;

    [SerializeField]
    float fuel = 500f;

    [SerializeField]
    float torque = 10f;

    float ang = 10f;

    [SerializeField]
    TextMeshProUGUI fueltxt;

    float maxrel = 2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(fuel > 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * vel * Time.deltaTime);
                fuel -= 10f * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque(Time.deltaTime * torque);
                fuel -= 5f * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque(-Time.deltaTime * torque);
                fuel -= 5f * Time.deltaTime;
            }
        }
        fueltxt.text = "Fuel = " + System.Convert.ToInt32(fuel).ToString();

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.relativeVelocity.magnitude //velocidade relativa dos objetos

        if (collision.gameObject.tag == "Plataforma" && Mathf.Abs(transform.localEulerAngles.z) <= ang && collision.relativeVelocity.magnitude > maxrel) //não percebo o porque de esta linha estar a dar erro com o angulo do lander
        {
            
            Debug.Log(transform.localEulerAngles.z);
            Debug.Log("Aterrei..");
        }
        else
        {
            Debug.Log(transform.localEulerAngles.z);
            Debug.Log("Explodi");
        }
    }
}
