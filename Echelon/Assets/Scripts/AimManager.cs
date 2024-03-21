using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimManager : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 1;
    float xAxis, yAxis;
    Transform followPoint;
    [SerializeField] Transform standingfollowPoint;
    [SerializeField] Transform crouchingfollowPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor to the center of the game window
        Cursor.lockState = CursorLockMode.Locked;
        // Hide cursor
        Cursor.visible = false;
        //followPoint = standingfollowPoint;
    }

    // Update is called once per frame
    void Update()
    {

        xAxis += Input.GetAxis("Mouse X") * mouseSensitivity;
        yAxis -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        yAxis = Mathf.Clamp(yAxis, -80, 80);
    }
    /* changing the aimpoint to 0 will change the aimpoint to standing aimpoint and changing it to 1 will change it to crouching aimpoint
    public void changeAimPoint(int aimPoint)
    {
        if (aimPoint == 0)
        {
            followPoint = standingfollowPoint;
        }
        else
        {
            followPoint = crouchingfollowPoint;
        }

    }
*/
    private void LateUpdate()
    {
        followPoint.localEulerAngles = new Vector3(yAxis, followPoint.localEulerAngles.y, followPoint.localEulerAngles.z);
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }
}
