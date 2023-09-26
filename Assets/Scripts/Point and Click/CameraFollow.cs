using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing; // velocidad a la que se va a mover la camara

    Vector3 offset;
    void Start()
    {
        // calculo la distancia inicial que hay entre camara y player
        offset = transform.position - player.position; 
    }

    void Update()
    {
        // calculo el punto al que quiero que se dirija la camara
        Vector3 targetCamPos = player.position + offset;

        // muevo la camara
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
