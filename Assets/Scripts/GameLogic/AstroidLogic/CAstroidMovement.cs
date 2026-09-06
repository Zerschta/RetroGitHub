using Unity.Mathematics;
using UnityEngine;

public class CAstroidMovement : MonoBehaviour
{

    public float RanSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //RanSpeed = UnityEngine.Random.Range(0.05f, 0.07f);
        RanSpeed = 0.07f;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {

        transform.position += transform.up * RanSpeed;
        CheckCorner();
    }

    void CheckCorner()
    {
        if (transform.position.x <= -11 || transform.position.x >= 11)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y <= -6 || transform.position.y >= 6)
        {
            Destroy(gameObject);
        }
    }
}
