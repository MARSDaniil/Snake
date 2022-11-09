using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 inputController;
    public bool isGameOver = false;
    public float speed;


    private float xPosition;
    private float yPosition;
    private int xBoard = 20;
    private int yBoard = 11;
    private Vector2 StartPosition;


    private List<Transform> segments;
    public Transform segmentPrefab;
    private void Start()
    {
        GeneratePosition();
        StartCoordinatesVector();

        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    public void StartCoordinatesVector()
    {
        StartPosition = new Vector2(xPosition, yPosition);
        transform.position = StartPosition;
    }
    public void GeneratePosition()
    {
        xPosition = (int)Random.Range(-xBoard, xBoard);
        yPosition = (int)Random.Range(-yBoard, yBoard);
    }
    // Update is called once per frame
    void Update()
    {
        CheckInput();

    }

    private void Teleportate()
    {
        if(transform.position.x > xBoard || transform.position.x < -xBoard)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        if (transform.position.y > yBoard || transform.position.y < -yBoard)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }
  
    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            inputController = new Vector2(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            inputController = new Vector2(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            inputController = new Vector2(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            inputController = new Vector2(-1, 0);
        }
    }
    private void FixedUpdate()
    {
        if (isGameOver == false)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }
            CheckInput();
            this.transform.position = new Vector2(
               Mathf.Round(this.transform.position.x) + inputController.x,
               Mathf.Round(this.transform.position.y) + inputController.y

                );
            Teleportate();
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        if (other.tag == "Player")
        {
            isGameOver = true;
           
        }
    }
}
