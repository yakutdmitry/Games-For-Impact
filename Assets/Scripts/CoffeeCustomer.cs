using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.LowLevelPhysics2D;

public class CoffeeCustomer : MonoBehaviour
{
    private GameObject Till;
    private NavMeshAgent navMesh;
    public bool collected = false;
    public Animator[] animator;
    public GameObject cup;
    [SerializeField] private GameObject coffeRoot;
    [SerializeField] private Transform body;
    private void Start()
    {
        Till = GameObject.Find("CoffeeCustomerDestination");
        animator = GetComponentsInChildren<Animator>();
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        navMesh.SetDestination(Till.transform.position);
    }

    private void Update()
    {
        if (collected)
        {
            foreach (var anim in animator)
            {
                anim.SetBool("TakeOut", true);
            }
        }
    }

    public void CoffeeSpawn()
    {
        // Debug.Log(coffeRoot);
        // Debug.Log(cup);
        var obj = Instantiate(cup, coffeRoot.transform.position, coffeRoot.transform.rotation);
        obj.transform.SetParent(coffeRoot.transform, true);
    }

}
