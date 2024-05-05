using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnColorOnHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = Color.red;    }
}
