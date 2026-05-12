using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            move.y = 1;

        if (Input.GetKey(KeyCode.S))
            move.y = -1;

        if (Input.GetKey(KeyCode.A))
            move.x = -1;

        if (Input.GetKey(KeyCode.D))
            move.x = 1;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move.normalized * speed * Time.fixedDeltaTime);
    }
}