using System;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Customer; // put repair customer to the end so that
                                                    // regular customers continue to spwan
                                                    // without spawning new repair customers
    
    [SerializeField] private float SpawnRate = 10;
    private float timer = 0;
    public bool repairCustomerIsSpawned;
    [SerializeField] private incomeManager incomeManager;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        timer = SpawnRate;
        if (incomeManager.finished)
        {
            Instantiate(Customer[Customer.Length - 1], gameObject.transform.position, transform.rotation);
            incomeManager.finished = false;
        }
        else
        {
            Instantiate(Customer[0], gameObject.transform.position, transform.rotation); // convert to range to spawn random customers appereances.
        }
        
        
    }
}
