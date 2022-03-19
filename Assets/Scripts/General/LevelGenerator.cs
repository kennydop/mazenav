using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{
    public Texture2D LevelPic;
    public GameObject Cube;
    public GameObject Parent;
    void Start()
    {
        int worldx = LevelPic.width;
        int worldz = LevelPic.height;

        Color[] pixels = LevelPic.GetPixels();

        Vector3[] SpawnPositions = new Vector3[pixels.Length];
        Vector3 startingSpawnPosition = new Vector3(Mathf.Round(worldx / 5), 0, Mathf.Round(worldz/5));
        Vector3 currentSpawnPosition = startingSpawnPosition;

        int counter = 0;

        for (int i = 0; i < worldz; i++)
        {
            for (int j = 0; j < worldx; j++)
            {
                SpawnPositions[counter] = currentSpawnPosition;
                counter++;
                currentSpawnPosition.x++;
            }
            currentSpawnPosition.x = startingSpawnPosition.x;
            currentSpawnPosition.z++;
        }

        counter = 0;
        foreach (Vector3 pos in SpawnPositions)
        {
            Color c = pixels[counter];

            if (c.Equals(Color.black) || c.Equals(Color.grey))
            {
                Instantiate(Cube, pos, Quaternion.identity, Parent.transform);
            }

            counter++;
        }
    }

}
