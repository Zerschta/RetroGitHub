using UnityEngine;

public class CrosHair : MonoBehaviour
{
    [SerializeField] private GameObject CrosshairGo;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layer;
    GameObject Go;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Go = Instantiate(CrosshairGo);
        Go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, layer);

        if (hit.collider != null)
        {
            Go.transform.position = hit.point;
            Go.SetActive(true);
        }
        else {
            Go.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.up * distance, Color.red);
    }
}
