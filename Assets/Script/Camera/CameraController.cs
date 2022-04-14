using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform cameraTransform;
    Transform playerTransform;
    Rigidbody2D cameraRb;
    public float cameraSpeed = 10.0f;
    bool cameraMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraRb = GetComponent<Rigidbody2D>();

        cameraTransform.position = playerTransform.position;
        cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, -100);
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cameraMoving = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            cameraMoving = true;
        }
    }

    private void CameraMove()
    {

        cameraTransform.position = playerTransform.position;
        cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, -100);

        /*
        if (cameraMoving)
        {
            if (cameraTransform.position.x + 0.1 < playerTransform.position.x)//プレイヤーが右、カメラが左
            {
                //cameraTransform.position = new Vector3(cameraTransform.position.x + 0.1f, cameraTransform.position.y, cameraTransform.position.z);//カメラを右に
                cameraRb.AddForce(new Vector2(cameraSpeed, 0));//カメラを右に
                //cameraRb.velocity = new Vector2(cameraSpeed, 0);
            }
            else if (playerTransform.position.x + 0.1 < cameraTransform.position.x)//逆
            {
                //cameraTransform.position = new Vector3(cameraTransform.position.x - 0.1f, cameraTransform.position.y, cameraTransform.position.z);//カメラを左に
                cameraRb.AddForce(new Vector2(-cameraSpeed, 0));//カメラを左に
                //cameraRb.velocity = new Vector2(-cameraSpeed, 0);
            }

            if (cameraTransform.position.y + 0.1 < playerTransform.position.y)//プレイヤーが上、カメラが下
            {
                //cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y + 0.1f, cameraTransform.position.z);//カメラを上に
                cameraRb.AddForce(new Vector2(0, cameraSpeed));//カメラを上に
                //cameraRb.velocity = new Vector2(0, cameraSpeed);
            }
            else if (playerTransform.position.y + 0.1 < cameraTransform.position.y)//逆
            {
                //cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y - 0.1f, cameraTransform.position.z);//カメラをに
                cameraRb.AddForce(new Vector2(0, -cameraSpeed));//カメラを下に
                //cameraRb.velocity = new Vector2(0, -cameraSpeed);
            }
        }
        */
    }
}
