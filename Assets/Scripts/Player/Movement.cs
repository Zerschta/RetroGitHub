using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{    
    bool PressedD;
    bool PressedA;
    bool PressedW;

    public float angle = 0;
    public float speed = 0;
    public float acceleration = 0;
    public float slowdown = 5f;
    public float rotspeed = 0;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (IsDead.Isdead == false)
        {
            if (PressedW)
            {
                rb.linearVelocity = Vector2.MoveTowards(
                   rb.linearVelocity,
                   transform.up * speed,
                   acceleration * Time.fixedDeltaTime
               );
            }
            else
            {
                rb.linearVelocity = Vector2.MoveTowards(
                    rb.linearVelocity,
                    Vector2.zero,
                    slowdown * Time.fixedDeltaTime
                );
            }
        }
        else { 
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead.Isdead == false)
        {
            CheckButton();

            if (angle >= 360) angle = 0;
            if (angle < 0) angle += 360;

            if (PressedA)
            {
                angle += rotspeed * Time.deltaTime;
            }
            else if (PressedD)
            {
                angle -= rotspeed * Time.deltaTime;
            }
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else { 
            return ;
        }
    }

    void CheckButton() {
        if (Input.GetKeyDown(KeyCode.A)) PressedA = true;
        if (Input.GetKeyUp(KeyCode.A)) PressedA = false;

        if (Input.GetKeyDown(KeyCode.D)) PressedD = true;
        if (Input.GetKeyUp(KeyCode.D)) PressedD = false;

        if (Input.GetKeyDown(KeyCode.W)) PressedW = true;
        if (Input.GetKeyUp(KeyCode.W)) PressedW = false;
    }

    

}

