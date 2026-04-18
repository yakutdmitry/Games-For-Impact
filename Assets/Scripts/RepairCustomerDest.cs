using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class RepairCustomerDest : MonoBehaviour
{
    [SerializeField] private GameObject popUP;
    [SerializeField] private GameObject workshopCamera;
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

    private void Update()
    {
        //if (workshopCamera.activeSelf)
        //{
        //    popUP.SetActive(false);
        //}
    }
}
