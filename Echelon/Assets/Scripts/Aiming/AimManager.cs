using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimManager : MonoBehaviour
{
    public Animator anim;

    AimBaseState currentState;
    public HipfireState Hip = new HipfireState();
    public AimState Aim = new AimState();

    public CinemachineVirtualCamera vCam;
    public float adsFOV = 40f;
    public float hipFOV;
    public float currFOV;
    public float adsSpeed = 10f;

    [SerializeField] float mouseSensitivity = 1f;
    float xAxis, yAxis;
    [SerializeField] Transform followPoint;

    public Transform aimPos;
    [SerializeField] float aimSmoothSpeed = 20f;
    [SerializeField] LayerMask aimLayerMask;

    void Start()
    {
        // Lock cursor to the center of the game window
        Cursor.lockState = CursorLockMode.Locked;
        // Hide cursor
        Cursor.visible = false;

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

        currentState.UpdateState(this);

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimLayerMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
        }



    }
    private void LateUpdate()
    {
        followPoint.localEulerAngles = new Vector3(yAxis, followPoint.localEulerAngles.y, followPoint.localEulerAngles.z);
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);


    }
    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

}
