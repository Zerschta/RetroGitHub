using System;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    public float size;
    public float RanSpeed;
    public int RandomRotation;
    public GameObject left;
    public GameObject right;

    Rigidbody2D rb;

    public GameObject CrackedAst;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RanSpeed = UnityEngine.Random.Range(0.03f, 0.05f);
        size = UnityEngine.Random.Range(0.5f , 1);
        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet") || collision.collider.gameObject.CompareTag("Astroid"))
        {
            Destroy(gameObject);
            SpawnCrackedAst();

        }
        else if (collision.collider.gameObject.CompareTag("CrackedAstroid")) {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            SpawnCrackedAst();
        }
    }

    void SpawnCrackedAst() {

        float Zmore = transform.eulerAngles.z + 20;
        float Zless = transform.eulerAngles.z - 20;

        CrackedAst.transform.position = left.transform.position;
        CrackedAst.transform.localScale = new Vector3(size / 1.5f, size / 1.5f, 0);
        CrackedAst.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, Zmore);
        Instantiate(CrackedAst);

        CrackedAst.transform.position = right.transform.position;
        CrackedAst.transform.localScale = new Vector3(size / 1.5f, size / 1.5f, 0);
        CrackedAst.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, Zless);
        Instantiate(CrackedAst);
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
