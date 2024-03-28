using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBloom : MonoBehaviour
{
    [SerializeField] float defualtBloomAngle = 3;
    [SerializeField] float walkBloomMultiplier = 1.5f;
    [SerializeField] float sprintBloomMultiplier = 2f;
    [SerializeField] float crouchBloomMultiplier = 0.5f;
    [SerializeField] float adsBloomMultiplier = 0.5f;

    Movement movement;
    AimManager aimManager;

    float currentBloom;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponentInParent<Movement>();
        aimManager = GetComponentInParent<AimManager>();
    }

    public Vector3 bloomAngle(Transform barrelPos)
    {
        if (movement.currentState == movement.Idle) currentBloom = defualtBloomAngle;
        else if (movement.currentState == movement.Walk) currentBloom = defualtBloomAngle * walkBloomMultiplier;
        else if (movement.currentState == movement.Sprint) currentBloom = defualtBloomAngle * sprintBloomMultiplier;
        else if (movement.currentState == movement.Crouch)
        {
            if (movement.dir.magnitude == 0) currentBloom = defualtBloomAngle * crouchBloomMultiplier;
            else currentBloom = defualtBloomAngle * crouchBloomMultiplier * walkBloomMultiplier;
        }

        if (aimManager.currentState == aimManager.Aim) currentBloom *= adsBloomMultiplier;

        float randX = Random.Range(-currentBloom, currentBloom);
        float randY = Random.Range(-currentBloom, currentBloom);
        float randZ = Random.Range(-currentBloom, currentBloom);

        Vector3 randomRotation = new Vector3(randX, randY, randZ);
        return barrelPos.localEulerAngles + randomRotation;
    }
}
