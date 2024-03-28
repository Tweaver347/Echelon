using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [SerializeField] private Transform recoilFollowPos;
    [SerializeField] private float kickbackAmount = -1;
    [SerializeField] private float kickbackSpeed = 10, returnSpeed = 20;
    float currentRecoilPos, finalRecoilPos;

    // Update is called once per frame
    void Update()
    {
        currentRecoilPos = Mathf.Lerp(currentRecoilPos, 0, returnSpeed * Time.deltaTime);
        finalRecoilPos = Mathf.Lerp(finalRecoilPos, currentRecoilPos, kickbackSpeed * Time.deltaTime);
        recoilFollowPos.localPosition = new Vector3(0, 0, finalRecoilPos);

    }

    public void triggerRecoil() => currentRecoilPos += kickbackAmount;
}
