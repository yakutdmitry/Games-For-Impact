using System;
using UnityEngine;
using UnityEngine.AI;

public class RepairCustomerDest : MonoBehaviour
{
    public GameObject popUP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RepairCustomer"))
        {
            other.GetComponent<NavMeshAgent>().isStopped = true;
            popUP.SetActive(true);
        }
    }
}
