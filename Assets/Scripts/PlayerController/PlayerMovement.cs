using UnityEngine;

public enum PlayerState
{
    IsMoving,
    IsStanding
}

public enum RotationSectorOnScreen
{
    Left,
    Up,
    Right,
    Down,
    LeftUp,
    RightUp,
    LeftDown,
    RightDown,
    Center
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    AnimationCurve MovCurve;
    Rigidbody2D rb;
    [SerializeField]
    float speed = 5f;

    [SerializeField] bool isStandingStill = true;

    [SerializeField] PlayerAnimationController playerAnimationController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        var horizontalInput = (Input.GetAxis("Horizontal"));
        var verticalInput = (Input.GetAxis("Vertical"));
        rb.velocity =( new Vector2(MovCurve.Evaluate(horizontalInput)*Mathf.Sign(horizontalInput), MovCurve.Evaluate(verticalInput)*Mathf.Sign(verticalInput)) * speed);

        PlayerState moveState = playerAnimationController.GetMoveState(horizontalInput, verticalInput);

        if(moveState == PlayerState.IsStanding)
        {
            HandleLookRotation();
        }

    }

    void HandleLookRotation()
    {

        // Screen Segments too check mouseposition for

        //       |     |
        //       |     |
        //   1   |  2  |    3
        //       |     |
        //       |     |
        // ----------------------
        //   4   |  -  |    5
        // ----------------------
        //       |     |
        //       |     |
        //   6   |  7  |    8
        //       |     |
        //       |     |

        // 1 = Look Left-Up
        // 2 = Look Up
        // 3 = Look Right-Up
        // 4 = Look Left
        // - = Do nothing (look down)
        // 5 = Look Right
        // 6 = Look Left-Down
        // 7 = Look Down
        // 8 = Look Right-Down

        var mousePosOnScreen = Input.mousePosition;
        //Debug.Log("Raw MousePos: " + mousePosOnScreen);

        RotationSectorOnScreen mouseIsInSector = RotationSectorOnScreen.Center;

        // todo: decide what sector the mouse is in and play the animation for it

        // draw debug lines to see the sectors visually
        Vector3 middleLineStart = Camera.main.ScreenToViewportPoint(new Vector3(0, Screen.height/2, 0));
        Vector3 middleLineEnd = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height/2, 0));

        Debug.DrawLine(middleLineStart, middleLineEnd, Color.green);


        playerAnimationController.PlayLookAnimation(mouseIsInSector);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("LevelTrigger"))
        {
            this.transform.parent.GetComponent<BasicGameLogic>().BeginNextLevel();
            Destroy(collision.gameObject);
        }
    }


}
