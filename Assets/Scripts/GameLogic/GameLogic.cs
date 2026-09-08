using System.Collections;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    
    public GameObject Astroid;
    public GameObject player;
    public int counter = 9; // max 10

    void Update()
    {
        SpawnAstroid();
        
    }
   

    Vector2 GetFreeSpawnPosition(float checkRadius, int maxAttempts)
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector2 candidate = RanWall();
            Collider2D hit = Physics2D.OverlapCircle(candidate, checkRadius);

            if (hit == null)
            {
                return candidate;
            }
        }
        return RanWall();
    }

    Vector2 RanWall() {
        ArrayList RanSpawnVector = new ArrayList();

        int X = UnityEngine.Random.Range(-13 , 13); // Y = -6 or Y = 6
        int Y = UnityEngine.Random.Range(-6, 6); // X = -11 or 11

        Vector2 Left = new Vector2(-13, Y); // left
        Vector2 Right = new Vector2(13, Y); // right
        Vector2 Top = new Vector2(X, -6); // top
        Vector2 Bottom = new Vector2(X, 6); // bottom

        RanSpawnVector.Add(Left);
        RanSpawnVector.Add(Right);
        RanSpawnVector.Add(Top);
        RanSpawnVector.Add(Bottom);

        int ranValue = UnityEngine.Random.Range(0, 4);
        Vector2 Fin;

        Fin = (Vector2)RanSpawnVector[ranValue];
        RanSpawnVector.Clear();
        
        return (Fin);
    }

    void SpawnAstroid()
    {
        int value = GameObject.FindGameObjectsWithTag("Astroid").Length;

        while (value <= counter)
        {
            float ranRot = UnityEngine.Random.Range(0f, 360f);

            Vector2 spawnPos = GetFreeSpawnPosition(2f, 20);

            Vector2 direction = (Vector2)player.transform.position - spawnPos;

            int random = UnityEngine.Random.Range(40, 140);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Instantiate(
                Astroid,
                spawnPos,
                Quaternion.Euler(0f, 0f, angle - random)
            );

            value++;

        }
    }
}
