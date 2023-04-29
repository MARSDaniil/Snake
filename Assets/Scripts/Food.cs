using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class Food : MonoBehaviour
{
    private float xPosition;
    private float yPosition;
    private int xBoard = 19;
    private int yBoard = 10;
    private Vector2 StartPosition;

    public bool isContact = false;


    public BoxCollider2D gridArea;


    public int score = 0;
    public Text ScoreText;
    private void Start()
    {
        StartCoordinatesVector();

       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {  
            StartCoordinatesVector();
            transform.position = StartPosition;
            score++;
        }

    }
   
    public void StartCoordinatesVector()
    {
        GeneratePosition();
        StartPosition = new Vector2(xPosition, yPosition);
        transform.position = StartPosition;
    }
    public void GeneratePosition()
    {
        xPosition = (int)Random.Range(-xBoard, xBoard);
        yPosition = (int)Random.Range(-yBoard, yBoard);
    }

    private void Update()
    {
        ScoreText.text = "Ваш результат = " + score.ToString();
    }
}
