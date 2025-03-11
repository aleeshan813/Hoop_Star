using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_position : MonoBehaviour
{
    private bool hasMoved = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bot")))
        {
            if (!hasMoved)
            {
                ChangeBallPosition();
                hasMoved = true;
            }
            else
            {
                hasMoved = false;
            }
        }
    }

    void ChangeBallPosition()
    {
        float randomX = Random.Range(-1f, 1f);
        Vector3 randomPosition = new Vector3(
            randomX,    
            transform.position.y, 
            transform.position.z 
        );

        // Move the ball to the new position
        transform.position = randomPosition;

        Debug.Log("Ball moved to: " + randomPosition);
    }
}