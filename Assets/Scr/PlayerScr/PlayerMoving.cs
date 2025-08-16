using Assets.Scr;
using System.Data.SqlTypes;
using System.IO;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoving : PVTBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public float currentSpeed = 0f;
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float rotationSpeed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    private Vector3 velocity;
    private bool isGrounded;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public static string animationState = "idle";
    protected override void loadComponents()
    {
        loadPlayerCtrl();
    }
    
    private void loadPlayerCtrl()
    {
        if (playerCtrl != null)
            return;
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }
    public void AnimationController()
    {
        switch (animationState)
        {
            case "Run":
                playerCtrl.Animator.SetBool("isRuning", true);
                playerCtrl.Animator.SetBool("isFlatRun", false);
                playerCtrl.Animator.SetBool("isJump", false);
                break;
            case "FlatRun":
                playerCtrl.Animator.SetBool("isRuning", false);
                playerCtrl.Animator.SetBool("isFlatRun", true);
                playerCtrl.Animator.SetBool("isJump", false);
                break;
            case "Jump":
                playerCtrl.Animator.SetBool("isRuning", false);
                playerCtrl.Animator.SetBool("isFlatRun", false);
                playerCtrl.Animator.SetBool("isJump", true);
                break;
            default:
                playerCtrl.Animator.SetBool("isRuning", false);
                playerCtrl.Animator.SetBool("isFlatRun", false);
                playerCtrl.Animator.SetBool("isJump", false);
                break;
        }
    }
    protected override void Update()
    {
        isGrounded = playerCtrl.Controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        bool flag = Input.GetKey(KeyCode.LeftShift);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCtrl.CameraTarget.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(playerCtrl.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            playerCtrl.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            currentSpeed = flag ? 8f : moveSpeed;
            playerCtrl.Controller.Move(moveDir.normalized *currentSpeed* Time.deltaTime);
            if(!playerCtrl.ParticleSystem.isPlaying)
            {
                playerCtrl.ParticleSystem.Play();
            }
            
        }
        else if (playerCtrl.ParticleSystem.isPlaying)
            playerCtrl.ParticleSystem.Stop();
        if (isGrounded && direction.magnitude >= 0.1f)
            animationState = flag ? "FlatRun" : "Run";
        if (!isGrounded)
            animationState = "Jump";
        else if (direction.magnitude == 0f)
            animationState = "idle";
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        playerCtrl.Controller.Move(velocity * Time.deltaTime);
        AnimationController();
    }
  
}
