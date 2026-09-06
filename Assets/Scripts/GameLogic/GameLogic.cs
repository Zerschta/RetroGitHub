using System.Collections;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    
    public GameObject Astroid;
    public int counter = 9; // max 10

    void Update()
    {
        SpawnAstroid();
    }

    Vector2 RanWall() {
        ArrayList RanSpawnVector = new ArrayList();

        int X = UnityEngine.Random.Range(-11 , 11); // Y = -6 or Y = 6
        int Y = UnityEngine.Random.Range(-6, 6); // X = -11 or 11

        Vector2 Left = new Vector2(-11, Y); // left
        Vector2 Right = new Vector2(11, Y); // right
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

    void SpawnAstroid() {
        int value = GameObject.FindGameObjectsWithTag("Astroid").Length;

        while (value <= counter) {            
            Vector2 SpawnPos = RanWall();
            float ranRot = UnityEngine.Random.Range(0, 360);
            Instantiate(Astroid, SpawnPos, Quaternion.Euler(0,0, ranRot));
            
            value++;
        }
    }
}
