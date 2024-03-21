using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
public class Movement : MonoBehaviour
{

    public float currentMoveSpeed;
    public float walkSpeed = 3, walkBackSpeed = 2;
    public float sprintSpeed = 7, sprintBackSpeed = 5;
    public float crouchSpeed = 2, crouchBackSpeed = 1;
    public Vector3 dir;
    public float horzInput, vertInput;
    CharacterController controller;

    [SerializeField] private float groundYOffset;
    [SerializeField] private LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] private float gravity = -9.81f;
    Vector3 velocity;

    MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public SprintState Sprint = new SprintState();
    public CrouchState Crouch = new CrouchState();

    public Animator anim;
    public AimManager aimManager;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        aimManager = GetComponent<AimManager>();

        SwitchState(Idle);
    }

    void Update()
    {
        GetDirectionAndMove();
        Gravity();

        anim.SetFloat("hInput", horzInput);
        anim.SetFloat("vInput", vertInput);

        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);

    }

    void GetDirectionAndMove()
    {
        horzInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        dir = transform.forward * vertInput + transform.right * horzInput;

        controller.Move(dir.normalized * currentMoveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePos, controller.radius - 0.05f);
    }
}
