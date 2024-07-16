using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject obstaclePrefab;

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        for (int i = 0; i < obstacleData.obstacleGrid.Length; i++)
        {
            if (obstacleData.obstacleGrid[i])
            {
                int x = i % 10;
                int y = i / 10;
                Instantiate(obstaclePrefab, new Vector3(x, 1.5f, y), Quaternion.identity);
            }
        }
    }
}
