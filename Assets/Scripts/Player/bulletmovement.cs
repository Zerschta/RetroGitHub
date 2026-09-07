using UnityEngine;

public class bulletmovement : MonoBehaviour
{
    Rigidbody2D rb;
    

    public float Speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {       
        CheckCorner();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * Speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Astroid") || collision.collider.gameObject.CompareTag("CrackedAstroid")) {

            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
        }
    }

    void CheckCorner() {
        if (transform.position.x <= -11 || transform.position.x >= 11)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y <= -6 || transform.position.y >= 6) { 
            Destroy(gameObject);
        }
    }
}
