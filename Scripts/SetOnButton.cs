using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetOnButton : MonoBehaviour
{
    private MovePlayer movePlayer;
    [SerializeField] GameObject button;
    //[SerializeField] Button button;


    public void Start()
    {
        movePlayer = GameObject.Find("SnakeBlockHead").GetComponent<MovePlayer>();
        // button.interactable = false;
        button.gameObject.SetActive(false);
    }
    void Update()
    {
        

        if (movePlayer.isGameOver == true)
        {
            //   button.enabled = true;
            button.gameObject.SetActive(true);
        }

    }
}
