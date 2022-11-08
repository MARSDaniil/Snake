using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 inputController;
    private string inputKey;
    public float speed;

   
    
    // Update is called once per frame
    void Update()
    {
        CheckInput();

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
        CheckInput();
        this.transform.position = new Vector2(
           Mathf.Round(this.transform.position.x) + inputController.x,
           Mathf.Round(this.transform.position.y) + inputController.y
           
            ) ;
        
    }
}
