using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour
{
    Rigidbody[] rbs;
    Animator anim;
    public GameObject gunObj;
    public UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {

        rbs = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TriggerRagdoll()
    {
        anim.enabled = false;
        // deactivate gun object
        gunObj.SetActive(false);
        agent.enabled = false;

        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
        }
    }
}
