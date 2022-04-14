using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSensorController : MonoBehaviour
{
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerController.isFloor_True();
        }
        if (collision.gameObject.tag == "Goal")
        {
            playerController.isFloor_True();
            playerController.isGoal_True();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerController.isFloor_False();
        }
        if (collision.gameObject.tag == "Goal")
        {
            playerController.isFloor_False();
            playerController.isGoal_False();
        }
    }
}
