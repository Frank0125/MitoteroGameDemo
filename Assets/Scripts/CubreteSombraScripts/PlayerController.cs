using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public LogicManager logicManager;
    private PlayerInput playerInput;
    public PlayerData playerData;

    [SerializeField]
    private float playerSpeed = 5.0f;
    private int index;

    private Rigidbody2D rb;
    public bool isInside;
    public bool isAnAlien = false;

    private Vector2 movementInput = Vector2.zero;

    private void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        index = playerInput.playerIndex;

        if (index == 0)
        {
            gameObject.name = "Alien!!";
            isAnAlien = true;
            animator.SetBool("isAlien", true);
        }
        else
        {
            gameObject.name = "Humano " + index;
        }


    }

    // Called by the Input System when movement input is detected
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (!logicManager.timesUp)
        {
            // Check for horizontal movement
            Vector2 move = new Vector2(movementInput.x * playerSpeed, movementInput.y * playerSpeed);
            rb.velocity = move;

            animator.SetFloat("xVelocity", rb.velocity.x);
            animator.SetFloat("YVelocity", rb.velocity.y);

            if (isAnAlien)
            {
                if (rb.velocity.y != 0)
                {
                    animator.SetBool("isAlienMovintY", true);
                }
                else
                {
                    animator.SetBool("isAlienMovintY", false);
                }
            }
            else
            {

                if (rb.velocity.y != 0)
                {
                    animator.SetBool("isMovingY", true);
                }
                else
                {
                    animator.SetBool("isMovingY", false);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            if (isInside)
            {
                playerData.AddPoints(index, 1);
                Debug.Log(gameObject.name + " ha sobrevivido");
                Debug.Log(playerData.GetPlayerPoints(index));
            }
            else
            {
                animator.SetBool("isDust", true);
            }

            logicManager.StartChangingScenene();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Clouds"))
        {
            isInside = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Clouds"))
        {
            isInside = false;
        }
    }
}
