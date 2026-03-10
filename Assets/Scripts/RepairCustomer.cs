using UnityEngine;
using UnityEngine.AI;

public class RepairCustomer : MonoBehaviour
{
    public Transform repairDest;
    void Start()
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(repairDest.position);
    }
}
