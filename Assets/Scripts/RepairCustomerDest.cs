using System;
using UnityEngine;
using UnityEngine.AI;

public class RepairCustomerDest : MonoBehaviour
{
    [SerializeField] private GameObject popUP;
    public Transform GarmentSpawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RepairCustomer"))
        {
            popUP = GameObject.Find("PopupManager").transform.Find("Popup1").gameObject;
            other.GetComponent<NavMeshAgent>().isStopped = true;
            popUP.SetActive(true);
            Instantiate(other.GetComponent<RepairCustomer>().pickedClothing, GarmentSpawner);
            
        }
    }
}
