using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LeftWalkController : MonoBehaviour
{
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_Up()
    {
        playerController.LeftStop();
    }
    public void Button_Down()
    {
        playerController.LeftWalk();
    }
}
