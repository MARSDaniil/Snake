using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class MovePlayer : MonoBehaviour
{

    private GameObject foodGameObject;
    private Food food;

    [SerializeField] AudioSource gameOverSound;
    [SerializeField] AudioSource foodSound;

    // Start is called before the first frame update
    private Vector2 inputController;
    public bool isGameOver = false;
    public float speed;


    private float xPosition;
    private float yPosition;
    private int xBoard = 19;
    private int yBoard = 10;
    private Vector2 StartPosition;


    private List<Transform> segments;
    public Transform segmentPrefab;


    private Vector2 tapPosition;
    private Vector2 swipeDelta;
    private bool isSwiping = false;
    [SerializeField]
    float deadZone = 30;
    [SerializeField]
    private string nameOfLeadTable;

    private void Awake()
    {
        foodGameObject = GameObject.Find("Food");
        food = foodGameObject.GetComponent<Food>();
    }



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
        if(transform.position.x > xBoard+1|| transform.position.x < -xBoard-1)
        {
            transform.position = new Vector2(-transform.position.x + 1* Mathf.Sign(transform.position.x), transform.position.y);
        }
        if (transform.position.y > yBoard+1 || transform.position.y < -yBoard-1)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y+ 1 * Mathf.Sign(transform.position.y));
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

        Debug.Log(food.score);
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
            foodSound.Play();
            Grow();
            
        }
        if ((other.tag == "Player") || (other.tag == "Wall"))
        {
            gameOverSound.Play();
            isGameOver = true;
            LeadBord(food.score);
        }
    }


    private void CheckInput()
    {
#if UNITY_STANDALONE || UNITY_WEBGL
       PcWeblGControll();
#endif
#if UNITY_IOS || UNITY_ANDROID
        IosAndroidControll();
#endif
    }
    void PcWeblGControll()

    {
        if (Input.GetAxis("Vertical") >0)
        {
            inputController = new Vector2(0, 1);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            inputController = new Vector2(0, -1);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            inputController = new Vector2(1, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            inputController = new Vector2(-1, 0);
        }
    }
    void IosAndroidControll()
    {
        if (Input.touchCount > 0)
        {
         //   Touch myTouch = Input.GetTouch(0);
         //   Vector2 positionOnScreen = myTouch.position;
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isSwiping = true;
                Vector2 positionOnScreen = Input.GetTouch(0).position;
            }
           else if (Input.GetTouch(0).phase==TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ResetSwipe();
            }
            CheckSwipe();
            ResetSwipe();
        }
    }
    private void ResetSwipe()
    {
        isSwiping = false;
        tapPosition = Vector2.zero;
        swipeDelta = Vector2.zero;
    }
    private void CheckSwipe()
    {
         swipeDelta = Vector2.zero;
         if (isSwiping)
         {
            swipeDelta = Input.GetTouch(0).position - tapPosition;
          }
         if(swipeDelta.magnitude > deadZone)
         {
            if(Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
                if(swipeDelta.x > 0)
                {
                    inputController = new Vector2(1,0);
                }
                else
                {
                    inputController = new Vector2(-1,0);
                }
            }
            else
            {
                if (swipeDelta.y > 0)
                {
                    inputController = new Vector2(0, 1);
                }
                else
                {
                    inputController = new Vector2(0, -1);
                }
            }
         }


    }


    private void LeadBord(int result)
    {

        YandexGame.NewLeaderboardScores(nameOfLeadTable, result);
    }

}
