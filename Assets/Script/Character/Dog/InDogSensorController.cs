using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDogSensorController : MonoBehaviour
{
    DogController dogController;
    bool isMob = false;
    bool isSend = true;

    // Start is called before the first frame update
    void Start()
    {
        dogController = transform.parent.GetComponent<DogController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsMob();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isMob = true;
        }
        if (collision.gameObject.tag == "Box")
        {
            isMob = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isMob = false;
        }
        if (collision.gameObject.tag == "Box")
        {
            isMob = false;
        }
    }

    private void IsMob()
    {
        if(isMob && isSend)
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
