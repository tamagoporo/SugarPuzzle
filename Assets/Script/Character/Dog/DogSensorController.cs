using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSensorController : MonoBehaviour
{
    DogController dogController;
    int inFloor = 0;
    bool isSend = true;

    // Start is called before the first frame update
    void Start()
    {
        dogController = transform.parent.GetComponent<DogController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsFloor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            inFloor++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            inFloor--;
        }
    }

    void IsFloor()
    {
        if (inFloor == 0 && isSend)
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
