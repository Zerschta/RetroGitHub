using UnityEngine;

public class bulletspawner : MonoBehaviour
{    
    public GameObject bullet;
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
