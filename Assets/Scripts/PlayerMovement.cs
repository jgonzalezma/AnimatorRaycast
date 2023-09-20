using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public GameObject colliderAttack; //va a hacer referencia al gameobject hijo que tiene el collider trigger

    float horizontal;
    float vertical;
    Vector3 movement; //Variable que me va a almacenar la direccion de movimiento
    Rigidbody rb;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Animating();
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Movimiento por transform
    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize(); //Normalizamos el vector (esto se hace para que vaya a la misma velocidad el movimiento, sino en las diagonales iría más rápido)
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void MovementTransform()
    {
        //transform.Translate(movement * speed * Time.deltaTime);
    }

    //Movimiento por rigidbody
    void Move()
    {
        InputPlayer();
        rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }

    void Animating()
    {
        if(horizontal != 0 || vertical != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && horizontal == 0 && vertical == 0)
        {
            anim.SetTrigger("Attack");
        }
    }

    void EnableColliderAttack()
    {
        colliderAttack.SetActive(true);
        Invoke("DisableCollider", 0.1f);
    }

    void DisableCollider()
    {
        colliderAttack.SetActive(false);
    }
}
