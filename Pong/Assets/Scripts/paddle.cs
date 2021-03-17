using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    [SerializeField]
    float velocity = 5f;

    [SerializeField]
    KeyCode upKey = KeyCode.UpArrow;
    [SerializeField]
    KeyCode downKey = KeyCode.DownArrow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            //transform.position =
            // transform.position + velocity * Vector3.up * Time.deltaTime;
            transform.position =
                transform.position += velocity * Vector3.up * Time.deltaTime;

        }
        else if (Input.GetKey(downKey))
        {
            transform.position =
                 transform.position + velocity * Vector3.down * Time.deltaTime;
        }

        float cameraHeight = Camera.main.orthographicSize;
        float halfPaddleSize = 0.5f;

        //if (transform.position.y >= cameraHeight - halfPaddleSize)
        //{
        //    Vector3 positionAux = transform.position;
        //    positionAux.y = cameraHeight - halfPaddleSize;
        //    transform.position = positionAux;
        //}
        //if (transform.position.y <= -cameraHeight - halfPaddleSize)
        //{
        //    Vector3 positionAux = transform.position;
        //    positionAux.y = -cameraHeight + halfPaddleSize;
        //    transform.position = positionAux;
        //}

        Vector3 positionAux = transform.position;
        positionAux.y = Mathf.Clamp(transform.position.y,
            -cameraHeight + halfPaddleSize,
            cameraHeight - halfPaddleSize);
        transform.position = positionAux;

        //codigo para ir para baixo
        //if (transform.position.y >= cameraHeight + halfPaddleSize)
        //{
        //    Vector3 positionAux = transform.position;
        //    positionAux.y = -cameraHeight - halfPaddleSize;
        //    transform.position = positionAux;
        //}
    }

}
