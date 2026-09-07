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
        size = UnityEngine.Random.Range(0.7f , 1.8f);
        transform.localScale = new Vector3(size, size, 0);
    }

    public class DestroyAfterAnimation : MonoBehaviour
    {
        [SerializeField] private float animationLength = 1f;

        private void Start()
        {
            Destroy(gameObject, animationLength);
        }
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
        int RanMoreZ = UnityEngine.Random.Range(17, 23);
        int RanLessZ = UnityEngine.Random.Range(17, 23);

        float Zmore = transform.eulerAngles.z + RanMoreZ;
        float Zless = transform.eulerAngles.z - RanLessZ;

        CrackedAst.transform.position = left.transform.position;
        CrackedAst.transform.localScale = new Vector3(size, size, 0);
        CrackedAst.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, Zmore);
        Instantiate(CrackedAst);

        CrackedAst.transform.position = right.transform.position;
        CrackedAst.transform.localScale = new Vector3(size, size, 0);
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
