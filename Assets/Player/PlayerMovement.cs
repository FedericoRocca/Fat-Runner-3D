using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float Rotationspeed;
    public float JumpForce;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Rotación
        if( moveHorizontal > 0 )
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), Rotationspeed * Time.deltaTime);
        }
        if( moveHorizontal < 0 )
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -180, 0), Rotationspeed * Time.deltaTime);
        }

        // Calculo del movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        Debug.Log("moveVertical " + moveVertical);
        // Salto
        if ((moveVertical > 0 || Input.GetKeyDown(KeyCode.Space)) && isGrounded == true)
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
}