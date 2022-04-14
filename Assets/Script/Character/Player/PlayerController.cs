using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    SEController sEController;
    GameObject GoalMenuCanvas;
    GameObject GoalMenuImage;
    Animator goalMenuAnimator;

    GameObject PlayerHead;
    Rigidbody2D rb;
    Animator animator;

    public bool IsEnabledKey { get; set; } = false;

    public float Speed { get; set; } = 5f;
    public float JumpPower { get; set; } = 5f;

    float xSpeed;
    
    bool isHide = false;
    bool isFloor = false;
    bool isJump = false;
    bool haveCookie = false;
    bool isGoad = false;

    private PlayerStates playerState = PlayerStates.Idle;
    private PlayerMoveStates playerMoveState = PlayerMoveStates.Stop;

    // Start is called before the first frame update
    void Start()
    {
        sEController = GameObject.Find("SEController").GetComponent<SEController>();
        GoalMenuCanvas = GameObject.Find("GoalMenuCanvas");
        goalMenuAnimator = GoalMenuCanvas.GetComponent<Animator>();
        GoalMenuImage = GoalMenuCanvas.transform.GetChild(0).gameObject;

        PlayerHead = gameObject.transform.GetChild(0).gameObject;
        PlayerHead.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();//x軸でのプレイヤーの移動

        if (IsEnabledKey)
        {
            KeyControl();//キー入力でのプレイヤーの処理
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cookie")
        {
            Debug.Log("クッキーおいしー！");
            sEController.Get();
            Destroy(collision.gameObject);
            haveCookie = true;
        }
    }

    public void ChangeMoveStateLeft()
    {
        if (playerState == PlayerStates.Goal || playerState == PlayerStates.Hide)
        {
            return;
        }
        switch (playerMoveState)
        {
            case PlayerMoveStates.Stop:
                playerMoveState = PlayerMoveStates.Left;
                break;
            case PlayerMoveStates.Right:
                playerMoveState = PlayerMoveStates.Stop;
                break;
        }
        MoveStateChangeHandler();
    }

    public void ChangeMoveStateRight()
    {
        if (playerState == PlayerStates.Goal || playerState == PlayerStates.Hide)
        {
            return;
        }
        switch (playerMoveState)
        {
            case PlayerMoveStates.Stop:
                playerMoveState = PlayerMoveStates.Right;
                break;
            case PlayerMoveStates.Left:
                playerMoveState = PlayerMoveStates.Stop;
                break;
        }
        MoveStateChangeHandler();
    }

    public void ChangeMoveStateStop()
    {
        playerMoveState = PlayerMoveStates.Stop;
        MoveStateChangeHandler();
    }

    public void MoveStateChangeHandler()
    {
        switch (playerMoveState)
        {
            case PlayerMoveStates.Stop:
                animator.SetTrigger("Idle");
                xSpeed = 0;
                break;
            case PlayerMoveStates.Left:
                animator.SetTrigger("LeftWalk");
                xSpeed = -Speed;
                break;
            case PlayerMoveStates.Right:
                animator.SetTrigger("RightWalk");
                xSpeed = Speed;
                break;
        }
    }

    public void Hide()
    {
        if (GoalMenuImage.GetComponent<RectTransform>().localScale.x == 0)
        {
            if (!isJump && isFloor)//ジャンプしていなく、床に足がついているなら
            {
                animator.SetTrigger("Hide");
                animator.SetBool("NotHide", false);
                isHide = true;
                PlayerHead.SetActive(true);

                if (isGoad)//床がゴール（角砂糖）なら
                {
                    Debug.Log("ゴールしました");
                    sEController.GameClear();
                    goalMenuAnimator.SetTrigger("Open");

                    if (SceneManager.GetActiveScene().name == "Stage1")
                    {
                        MenuStageController.stage1 = true;
                        if (haveCookie)
                        {
                            MenuStageController.cookie1 = true;
                        }
                    }
                    if (SceneManager.GetActiveScene().name == "Stage2")
                    {
                        MenuStageController.stage2 = true;
                        if (haveCookie)
                        {
                            MenuStageController.cookie2 = true;
                        }
                    }
                    if (SceneManager.GetActiveScene().name == "Stage3")
                    {
                        MenuStageController.stage3 = true;
                        if (haveCookie)
                        {
                            MenuStageController.cookie3 = true;
                        }
                    }
                    if (SceneManager.GetActiveScene().name == "Stage4")
                    {
                        MenuStageController.stage4 = true;
                        if (haveCookie)
                        {
                            MenuStageController.cookie4 = true;
                        }
                    }
                    if (SceneManager.GetActiveScene().name == "Stage5")
                    {
                        MenuStageController.stage5 = true;
                        if (haveCookie)
                        {
                            MenuStageController.cookie5 = true;
                        }
                    }
                    if (SceneManager.GetActiveScene().name == "Stage6")
                    {
                        MenuStageController.stage6 = true;
                        if (haveCookie)
                        {
                            MenuStageController.cookie6 = true;
                        }
                    }

                }
            }
        }
        
    }

    public void NotHide()
    {
        if (GoalMenuImage.GetComponent<RectTransform>().localScale.x == 0)
        {
            animator.SetBool("NotHide", true);
            isHide = false;
            PlayerHead.SetActive(false);
        }
    }

    public void Jump()
    {
        if (GoalMenuImage.GetComponent<RectTransform>().localScale.x == 0)
        {
            if (!isJump && !isHide && isFloor)//ジャンプしていなく、隠れていなく、床に足がついているなら
            {
                sEController.Jump();
                isJump = true;
                animator.SetTrigger("Jump");
            }
        }

    }

    private void MovePlayer()
    {
        if (isHide)//隠れている状態なら動かない
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        }
    }

    private void JumpPlayer()
    {
        if (isHide)//隠れている状態なら動かない
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.AddForce(new Vector2(0, JumpPower), ForceMode2D.Impulse);
        }
    }
    
    private void KeyControl()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeMoveStateLeft();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ChangeMoveStateStop();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeMoveStateRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            ChangeMoveStateStop();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Hide();
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            NotHide();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Jump();
        }
    }

    public enum PlayerStates
    {
        Idle,
        Hide,
        Jump, 
        Goal,
    }

    public enum PlayerMoveStates
    {
        Stop,
        Left,
        Right,
    }
}
