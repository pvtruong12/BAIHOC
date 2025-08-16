using Assets.Scr;
using UnityEngine;

public class Jumping : PVTBehaviour
{
    [SerializeField]private PlayerCtrl playerCtrl;
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    private Vector3 velocity;
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
    protected override void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && playerCtrl.Controller.isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}
        //playerCtrl.Controller.Move(velocity * Time.deltaTime);
    }
    
}
