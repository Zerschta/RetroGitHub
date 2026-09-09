using UnityEngine;

public class bulletmovement : MonoBehaviour
{
    Rigidbody2D rb;
    

    public float Speed;
    public GameObject explode;
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

            explode.transform.position = collision.GetContact(0).point;
            Instantiate(explode);
            Destroy(gameObject);
        }
    }

    void CheckCorner() {
        if (transform.position.x <= -14 || transform.position.x >= 14)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y <= -7 || transform.position.y >= 7) { 
            Destroy(gameObject);
        }
    }
}
