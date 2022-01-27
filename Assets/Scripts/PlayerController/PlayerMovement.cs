using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] bool isStandingStill = true;

    [SerializeField] PlayerAnimationController playerAnimationController;

    PlayerStats pStats;

    // Start is called before the first frame update
    void Start()
    {
        pStats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Player Speed: " + pStats.speed);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }


        if(this.transform.position.y >= 0.52f || this.transform.position.y <= -5.18f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -1.8f, 0);
                
        }

        var horizontalInput = (Input.GetAxis("Horizontal"));
        var verticalInput = (Input.GetAxis("Vertical"));



        rb.velocity =( new Vector2(MovCurve.Evaluate(horizontalInput)*Mathf.Sign(horizontalInput), MovCurve.Evaluate(verticalInput)*Mathf.Sign(verticalInput)) * pStats.speed);

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
        if(collision.transform.CompareTag("LeftBorderWall"))
        {
            SceneManager.LoadScene(2);
        }
    }


}
