using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FeedbackManager : MonoBehaviour
{
    public GameData Data;
    public TextMeshProUGUI DisplayedText;
    
    
    [SerializeField] private GameObject InventoryManager;
    [SerializeField] private incomeManager incomeManager;
    [SerializeField] private GameObject[] mascotPosees;
    
    private bool needsRepair;
    
    public void GenerateFeedback()
    {
        if(GameObject.FindWithTag("Garment") != null)
        {
            foreach (var pose in mascotPosees)
            {
                pose.SetActive(false);
            }
            
            needsRepair = GameObject.FindWithTag("Hole") != null || GameObject.FindWithTag("Corner") != null;
            Debug.Log("fEEDBACK FOUND " + GameObject.FindWithTag("Garment"));
            Debug.Log("needsRepair is " + needsRepair);
            Debug.Log("Found hole " + GameObject.FindWithTag("Hole"));
            Destroy(GameObject.FindWithTag("Garment"));
            Destroy(GameObject.FindWithTag("RepairCustomer"));
            incomeManager.finished = true;
            Debug.Log(InventoryManager.GetComponent<InventoryManager>().itemList.balance);
            // InventoryManager.GetComponent<InventoryManager>().itemList.balance += Random.Range(10, 25); //temp
            Debug.Log("Balance added");
            Debug.Log(InventoryManager.GetComponent<InventoryManager>().itemList.balance);
            // DisplayedText.text = Data.feedback[Random.Range(0, Data.feedback.Length)];
            
            
            // Display random mascot pose
            mascotPosees[Random.Range(0, mascotPosees.Length -1)].SetActive(true); 
        }
        
        
        if (needsRepair)
        {
            DisplayedText.text = Data.UnSucessfulfeedback[Random.Range(0, Data.Sucessfulfeedback.Length)];
            InventoryManager.GetComponent<InventoryManager>().itemList.balance += Random.Range(20, 35);
        }
        
        if (!needsRepair)
        {
            DisplayedText.text = Data.Sucessfulfeedback[Random.Range(0, Data.UnSucessfulfeedback.Length)];
            InventoryManager.GetComponent<InventoryManager>().itemList.balance += 10;
        }
    }
}
