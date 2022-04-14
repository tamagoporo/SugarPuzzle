using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDogSensorController : MonoBehaviour
{
    DogController dogController;
    bool isWall = false;
    bool isSend = true;

    // Start is called before the first frame update
    void Start()
    {
        dogController = transform.parent.GetComponent<DogController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsWall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWall = false;
        }
    }

    private void IsWall()
    {
        if (isWall && isSend)
        {
            isSend = false;
            Invoke("isSend_True", 1.5f);
            dogController.LookBack();
        }
    }
    void isSend_True()
    {
        isSend = true;
    }
}
