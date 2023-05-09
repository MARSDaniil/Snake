using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    private float xPosition;
    private float yPosition;
    private int xBoard = 8;
    private int yBoard = 4;
    //private float deviation = 0.5f;

    public BoxCollider2D gridArea;
   
    private Vector2 StartPosition;
    public GameObject Snake;
    public GameObject Food;
    // Start is called before the first frame update
    void Start()
    {

        //  GeneratePosition();
        //    StartCoordinatesVector();
        //   Instantiate(Snake, StartPosition, Snake.transform.rotation);
        InstantiateGameObject(Snake);
     //   InstantiateGameObject(Food);



    }

    private void Update()
    {
        
}
    private void InstantiateGameObject(GameObject gameObject)
    {
       
        GeneratePosition();
        StartCoordinatesVector();
        Instantiate(gameObject, StartPosition, Snake.transform.rotation);
    }
    public void GeneratePosition()
    {
        xPosition = (int)Random.Range(-xBoard, xBoard);
        yPosition = (int)Random.Range(-yBoard, yBoard);
    }
    public Vector2 StartCoordinatesVector()
    {
        StartPosition = new Vector2(xPosition, yPosition);
        return (new Vector2(xPosition, yPosition));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GeneratePosition();
            StartCoordinatesVector();
            Food.transform.position = StartPosition;
        }

    }
}
