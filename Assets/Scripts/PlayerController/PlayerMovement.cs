using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    AnimationCurve MovCurve;
    Rigidbody2D rb;
    [SerializeField]
    float speed = 5f;


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

        playerAnimationController.DecideWalkingAnimation(horizontalInput, verticalInput);

    }
}
