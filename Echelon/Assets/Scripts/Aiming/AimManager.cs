using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimManager : MonoBehaviour
{
    public Animator anim;

    public AimBaseState currentState;
    public HipfireState Hip = new HipfireState();
    public AimState Aim = new AimState();

    public CinemachineVirtualCamera vCam;
    public float adsFOV = 40f;
    public float hipFOV;
    public float currFOV;
    public float adsSpeed = 10f;

    [SerializeField] float mouseSensitivity = 1f;
    float xAxis, yAxis;
    [SerializeField] Transform camFollowPos;

    public Transform aimPos;
    [SerializeField] float aimSmoothSpeed = 20f;
    [SerializeField] LayerMask aimLayerMask;

    float xFollowPos;
    float yFollowPos, ogYPos;
    [SerializeField] float crouchCameraHeight = 0.6f;
    [SerializeField] float sholderSwapSpeed = 10f;
    Movement moving;

    void Start()
    {
        // Lock cursor to the center of the game window
        Cursor.lockState = CursorLockMode.Locked;
        // Hide cursor
        Cursor.visible = false;

        moving = GetComponentInParent<Movement>();
        xFollowPos = camFollowPos.localPosition.x;
        ogYPos = camFollowPos.localPosition.y;
        yFollowPos = ogYPos;
        anim = GetComponent<Animator>();
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();

        hipFOV = vCam.m_Lens.FieldOfView;
        SwitchState(Hip);

    }
    void Update()
    {

        xAxis += Input.GetAxis("Mouse X") * mouseSensitivity;
        yAxis -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        yAxis = Mathf.Clamp(yAxis, -80, 80);

        vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, currFOV, adsSpeed * Time.deltaTime);

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimLayerMask))
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);

        cameraFollowPoint();

        currentState.UpdateState(this);
    }
    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);


    }
    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void cameraFollowPoint()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            xFollowPos = -xFollowPos;
        }
        if (moving.currentState == moving.Crouch)
        {
            yFollowPos = crouchCameraHeight;
        }
        else
        {
            yFollowPos = ogYPos;
        }

        Vector3 newFollowPos = new Vector3(xFollowPos, yFollowPos, camFollowPos.localPosition.z);
        camFollowPos.localPosition = Vector3.Lerp(camFollowPos.localPosition, newFollowPos, sholderSwapSpeed * Time.deltaTime);
    }
}
