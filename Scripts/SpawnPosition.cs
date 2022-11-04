using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    private float xPosition;
    private float yPosition;
    private int xBoard = 8;
    private int yBoard = 4;
    private float deviation = 0.5f;
    private Vector2 StartPosition;
    public GameObject Snake;
    // Start is called before the first frame update
    void Start()
    {
        GeneratePosition();
        StartCoordinatesVector();
        Instantiate(Snake, StartPosition, Snake.transform.rotation);
    }

    private void GeneratePosition()
    {
        xPosition = (int)Random.Range(-xBoard + deviation, xBoard - deviation);
        yPosition = (int)Random.Range(-yBoard + deviation, yBoard - deviation);
    }
    private void StartCoordinatesVector()
    {
        StartPosition = new Vector2(xPosition, yPosition);
    }
}
