using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CoffeeCustomer : MonoBehaviour
{
    private GameObject Till;
    private NavMeshAgent navMesh;
    public bool collected = false;
    public Animator[] animator;
    public GameObject cup;
    private Transform coffeRoot;
    private void Start()
    {
        Till = GameObject.Find("CoffeeCustomerDestination");
        animator = GetComponentsInChildren<Animator>();
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        navMesh.SetDestination(Till.transform.position);
        coffeRoot = transform.Find("DEF-hand.R");
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
        Instantiate(cup, coffeRoot.position, coffeRoot.rotation);
    }
}
