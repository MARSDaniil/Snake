using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool isContact = false;
    SpawnPosition spawnPosition;
    // Start is called before the first frame update
    public BoxCollider2D gridArea;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isContact = true;
            spawnPosition.GeneratePosition();
            this.transform.position = spawnPosition.StartCoordinatesVector();
        }

    }
}
