using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] CoffeeCustomers;
    [SerializeField] private GameObject[] RepairCustomers;
    [SerializeField] private float SpawnRate = 10;
    [SerializeField] private float repairSpawnRate = 10;
    public float repairSpawn;
    private float timer = 0;
    public bool repairCustomerIsSpawned;
    [SerializeField] private incomeManager incomeManager;

    public GameObject InventoryManager;
    public GameObject notEnoughMaterials;
    public GameObject redDot;
    public GameObject redCafeDot;
    public GameObject redRepairDot;
    public Button finishRepairButton;
    private bool onCafe = true;
    public bool redText = false;

    private void Start()
    {
        notEnoughMaterials.SetActive(true);
        redDot.SetActive(true);
        redCafeDot.SetActive(true);
        redRepairDot.SetActive(true);

        repairSpawnRate = repairSpawn;
        InventoryManager.GetComponent<InventoryManager>().UpdateBalance();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (incomeManager.finished)
        {
            repairSpawnRate -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Spawn();
        }
        if (InventoryManager.GetComponent<InventoryManager>().itemList.item1Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item2Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item3Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item4Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item5Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item6Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item7Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item8Quantity > 0)
        {
            notEnoughMaterials.SetActive(false);
            redDot.SetActive(false);
            redText = false;
            redCafeDot.SetActive(false);
            redRepairDot.SetActive(false);
            InventoryManager.GetComponent<InventoryManager>().UpdateBalance();

        }
        else
        {
            if (onCafe)
            {
                notEnoughMaterials.SetActive(true);
                redDot.SetActive(true);
            InventoryManager.GetComponent<InventoryManager>().UpdateBalance();
                
            }
            redText = true;
            if (InventoryManager.GetComponent<InventoryManager>().itemList.item4Quantity <= 0 || InventoryManager.GetComponent<InventoryManager>().itemList.item5Quantity <= 0 || InventoryManager.GetComponent<InventoryManager>().itemList.item6Quantity <= 0 || InventoryManager.GetComponent<InventoryManager>().itemList.item7Quantity <= 0 || InventoryManager.GetComponent<InventoryManager>().itemList.item8Quantity <= 0)
            {
                redCafeDot.SetActive(true);
            }
            else
            {
                redCafeDot.SetActive(false);
            }
            if (InventoryManager.GetComponent<InventoryManager>().itemList.item1Quantity <= 0 || InventoryManager.GetComponent<InventoryManager>().itemList.item2Quantity <= 0 || InventoryManager.GetComponent<InventoryManager>().itemList.item3Quantity <= 0)
            {
                redRepairDot.SetActive(true);
            }
            else
            {
                redRepairDot.SetActive(false);
            }
            InventoryManager.GetComponent<InventoryManager>().UpdateBalance();
            
        }
    }

    private void Spawn()
    {
        InventoryManager.GetComponent<InventoryManager>().UpdateBalance();
        timer = SpawnRate;
        if (incomeManager.finished && repairSpawnRate <= 0)
        {
            Instantiate(RepairCustomers[Random.Range(0, RepairCustomers.Length - 1)], gameObject.transform.position, transform.rotation);
            incomeManager.finished = false;
            repairSpawnRate = repairSpawn;

            finishRepairButton.interactable = true;
        }
        else
        {
            if (InventoryManager.GetComponent<InventoryManager>().itemList.item4Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item5Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item6Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item7Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item8Quantity > 0)
            {
                Instantiate(CoffeeCustomers[Random.Range(0, CoffeeCustomers.Length - 1)], gameObject.transform.position, transform.rotation); // convert to range to spawn random customers appereances.
            }
        }    
    }

    public void OnCafe()
    {
        onCafe = true;
    }
    public void OffCafe()
    {
        onCafe = false;
        notEnoughMaterials.SetActive(false);
        redDot.SetActive(false);
    }
}
