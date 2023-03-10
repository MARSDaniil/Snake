
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOnText : MonoBehaviour
{
    private MovePlayer movePlayer;
    [SerializeField] Text text;

    public void Start()
    {
        movePlayer = GameObject.Find("SnakeBlockHead").GetComponent<MovePlayer>();
    }
    void Update()
    {
        text.enabled = false;
      
        if (movePlayer.isGameOver == true)
        {
            text.enabled = true;
        }
       
    }
}


