using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }

    // State machine
    public StateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkingState WalkingState { get; private set; }
    public PlayerJumpState JumpingState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerLandState LandState { get; private set; }


    [SerializeField] private PlayerData playerData;
    [SerializeField] private Transform groundCheckTransform;
    public Inputs Inputs { get; private set; } 
    private Vector2 velocity;
    public Vector2 playerVelocity { get; private set; }
    private int facingDirection;



    // Testing
    private WeapenSystem weapenSystem;
    [SerializeField] private WeaponSO newWeapon;

    private void Awake()
    {
        StateMachine = new StateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        WalkingState = new PlayerWalkingState(this, StateMachine, playerData, "Walk");
        JumpingState = new PlayerJumpState(this, StateMachine, playerData, "Jump");
        AirState = new PlayerAirState(this, StateMachine, playerData, "Jump");
        LandState = new PlayerLandState(this, StateMachine, playerData, "Land");
    }


    private void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Inputs = GetComponent<Inputs>();
        StateMachine.Init(IdleState);
        facingDirection = 1;
        weapenSystem = GetComponent<WeapenSystem>();
    }



    private void Update()
    {
        playerVelocity = Rb.velocity;
        StateMachine.CurrentState.Update();

        




    }

    

   

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicUpdate();
    }



    public void SetVelocityX(float _velocity)
    {
        velocity.Set(_velocity,playerVelocity.y);
        Rb.velocity = velocity;
        playerVelocity = velocity;
    }

    public void SetVelocityY(float _velocity)
    {
        velocity.Set(playerVelocity.x,_velocity);
        Rb.velocity = velocity;
        playerVelocity = velocity;
    }



    public void CheckShouldFlip(int xInput)
    {
        
       if(xInput != 0 && xInput != facingDirection)
       {
           Flip();
       }
    }


    public bool CheckIsGrounded()
    {
        return Physics2D.BoxCast(groundCheckTransform.position,playerData.groundCheckSize, 0, Vector2.down, 0.2f,playerData.groundLayerMask);
    }

    private void Flip()
    {
       facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }



    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();



    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(groundCheckTransform.position, playerData.groundCheckSize);
    }





    


    //will need
    private Vector3 GetMousePos()
   {
       Vector3 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection.z = 0;
        return mouseDirection;
   }

}
