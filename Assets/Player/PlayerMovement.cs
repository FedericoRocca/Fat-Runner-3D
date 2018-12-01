using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float Rotationspeed;
    public float JumpForce;

    private Rigidbody rb;
    private bool isGrounded = true;

    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        // Rotación
        // Derecha
        if( moveHorizontal > 0 )
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), Rotationspeed * Time.deltaTime);
        }
        // Izquierda
        if( moveHorizontal < 0 )
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 0), Rotationspeed * Time.deltaTime);
        }

        // Calculo del movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        // Salto
        if ( ((moveVertical > 0 || moveVertical < 0) || Input.GetKeyDown(KeyCode.Space)) && isGrounded == true)
        {
            movement.y = 1 * JumpForce;
            isGrounded = false;
        }

        // Movimiento
        rb.AddForce(movement * speed);
    }

    // Reseteo del salto
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    public bool getisGrounded()
    {
        return isGrounded;
    }

    public float getVelocity()
    {
        return rb.velocity.x;
    }
}