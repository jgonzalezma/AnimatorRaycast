using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastCamera : MonoBehaviour
{
    public LayerMask layerRay;
    Ray ray;
    RaycastHit hit;

    NavMeshAgent agent;
    Vector3 posToGo; // en esta variable voy a almacenar el punto al que quiero que se dirija el player
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        posToGo = transform.position;
    }

    void Update()
    {
        agent.SetDestination(posToGo);
        Animating();

        // Camera.main hace referencia a la camara de la escena que tenga la etiqueta de "MainCamera"
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerRay) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Estoy chocando en el suelo en el punto: " + hit.point);
            posToGo = hit.point;
        }
        Debug.DrawRay(ray.origin, ray.direction * 500, Color.red);
    }

    void Animating()
    {
        if (agent.velocity.magnitude == 0)
        {
            // esta parado
            anim.SetBool("IsWalking", false);
        }
        else
        {
            // esta caminando
            anim.SetBool("IsWalking", true);
        }
    }
}
