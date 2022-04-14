using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject Door;
    public bool open = true;

    Animator animator;
    CircleCollider2D circleCollider2D;
    Animator doorAnimator;
    BoxCollider2D doorBoxCollider2D;
    SEController sEController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        doorAnimator = Door.GetComponent<Animator>();
        doorBoxCollider2D = Door.transform.GetChild(0).GetComponent<BoxCollider2D>();
        sEController = GameObject.Find("SEController").GetComponent<SEController>();
        if (!open)
        {
            doorBoxCollider2D.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Dog" || collision.gameObject.tag == "Box")
        {
            if (open)
            {
                sEController.OpenGate();
                animator.SetTrigger("Push");
                circleCollider2D.enabled = false;
                doorAnimator.SetTrigger("Open");
                doorBoxCollider2D.enabled = false;
            }
            else
            {
                sEController.Fall();
                animator.SetTrigger("Push");
                circleCollider2D.enabled = false;
                doorAnimator.SetTrigger("Close");
                doorBoxCollider2D.enabled = true;
            }
        }
    }
}
