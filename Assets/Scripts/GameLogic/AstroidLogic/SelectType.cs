using UnityEngine;

public class SelectType : MonoBehaviour
{
    public SpriteRenderer RendererA;
    public SpriteRenderer RendererB;
    public SpriteRenderer RendererC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int ran = UnityEngine.Random.Range(0, 3);
        if (ran == 0) {
            RendererA.enabled = true;
            RendererB.enabled = false;
            RendererC.enabled = false;
        }
        else if (ran == 1) {
            RendererA.enabled = false;
            RendererB.enabled = true;
            RendererC.enabled = false;
        }
        else if (ran == 2) {
            RendererA.enabled = false;
            RendererB.enabled = false;
            RendererC.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
