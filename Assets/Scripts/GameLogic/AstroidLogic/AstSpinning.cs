using UnityEngine;

public class AstSpinning : MonoBehaviour
{
    public float RotSpeed;
    float StartValue = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RotSpeed = UnityEngine.Random.Range(0.01f, 0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        StartValue += RotSpeed;
        transform.rotation = Quaternion.Euler(0, 0, StartValue + RotSpeed);
    }
}
