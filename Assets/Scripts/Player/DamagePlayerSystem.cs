using System;
using UnityEngine;

public class DamagePlayerSystem : MonoBehaviour
{
    public SpriteRenderer Full;
    public SpriteRenderer HalfLife;
    public SpriteRenderer Dead;
    public GameObject explode;
    public int DamageValue;
    void Start()
    {
        DamageValue = 0;
        Full.enabled = true;
        HalfLife.enabled = false;
        Dead.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageValue++;

        Destroy(collision.collider.gameObject);
        explode.transform.position = collision.GetContact(0).point;
        Instantiate(explode);

        if (DamageValue == 0) {
            Full.enabled = true;
            HalfLife.enabled = false;
            Dead.enabled = false;
        }
        else if (DamageValue == 1) {
            Full.enabled = false;
            HalfLife.enabled = true;
            Dead.enabled = false;
        }
        else if (DamageValue == 2) {
            Full.enabled = false;
            HalfLife.enabled = false;
            Dead.enabled = true;
        }
        else if (DamageValue == 3) {
            Destroy(gameObject);
            IsDead.Isdead = true;
        }

    }
}
