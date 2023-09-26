using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastExample : MonoBehaviour
{
    public float lenghtRay;
    public LayerMask layerRay;
    Ray ray; //variable donde voy a guardar la configuracion del rayo
    RaycastHit hit; //variable donde se va a almacenar la informacion del choque entre raycast y gameobject(collider)

    void Start()
    {
        
    }

    void Update()
    {
        // CONFIGURACION DEL RAYCAST
        // el origen del raycast(que es una variable de tipo Vector3) es igual, en este caso, a la posicion (punto de pivote) del gameobject que lleva este script
        ray.origin = transform.position;
        // la direccion del rayo va a ser igual a la del eje Z (LOCAL) del gameobject que lleva este script
        ray.direction = transform.forward;

        //LANZAMIENTO DE RAYCAST
        if (Physics.Raycast(ray, out hit, lenghtRay, layerRay))
        {
            if (hit.collider.CompareTag("Object"))
            {
                // estoy accediendo al componente rigidbody del gamobject con el que esta cochando el raycast y le estoy añadiendo fuerza
                // en una direccion
                hit.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * 50);
            }
            //Debug.Log("Raycast está chocando con algo: " + hit.collider.name); 
        }

        Debug.DrawRay(ray.origin, ray.direction * lenghtRay, Color.red);
    }
}
