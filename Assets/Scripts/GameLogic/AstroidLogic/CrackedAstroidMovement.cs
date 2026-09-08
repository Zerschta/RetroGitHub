using Unity.Mathematics;
using UnityEngine;

public class CAstroidMovement : MonoBehaviour
{

    public float RanSpeed;
    public GameObject explode;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //RanSpeed = UnityEngine.Random.Range(0.05f, 0.07f);
        RanSpeed = 0.04f;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("CrackedAstroid"))
        {
            explode.transform.position = collision.GetContact(0).point;
            Instantiate(explode);
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
        }
    }

    private void FixedUpdate()
    {

        transform.position += transform.up * RanSpeed;
        CheckCorner();
    }

    void CheckCorner()
    {
        if (transform.position.x <= -14 || transform.position.x >= 14)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y <= -7 || transform.position.y >= 7)
        {
            Destroy(gameObject);
        }
    }
}
