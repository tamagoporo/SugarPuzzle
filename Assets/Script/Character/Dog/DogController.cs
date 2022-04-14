using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    Animator animator;
    DogSensorController dogSensor;
    Rigidbody2D dogRb;

    float time1 = 0f;

    bool isLeftWalk = false;
    bool isStop = false;

    public float dogSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        dogSensor = transform.GetChild(1).GetComponent<DogSensorController>();
        dogRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DogMove();
    }

    public void LookBack()
    {
        isLeftWalk = !isLeftWalk;
        animator.SetTrigger("Idle");
        isStop = true;
    }

    void DogMove()
    {
        if (!isStop)
        {
            if (isLeftWalk)//左に進む
            {
                dogRb.velocity = new Vector2(-dogSpeed, 0);
            }
            else//右に進む
            {
                dogRb.velocity = new Vector2(dogSpeed, 0);
            }
        }
        else//止まる
        {
            StopCount();
            dogRb.velocity = new Vector2(0, 0);
        }
    }

    void StopCount()
    {
        if(time1 < 1.0f)
        {
            time1 += Time.deltaTime;
        }
        else
        {
            time1 = 0f;
            isStop = false;
            if (isLeftWalk)
            {
                animator.SetTrigger("Left_W");
            }
            else
            {
                animator.SetTrigger("Right_W");
            }
        }
    }
}
