using UnityEngine;

public class bulletspawner : MonoBehaviour
{    
    public GameObject bullet;

    bool PressedSpace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet);
        }
    }
}
