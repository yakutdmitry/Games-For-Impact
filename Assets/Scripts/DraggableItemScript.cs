using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DraggableItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    private Vector3 startTransform;
    private GameObject camera;
    private bool canDrag;
    public GameObject Corner;
    private AudioSource sewingSFX;
    private int soundscount;
    public InventoryManager Inventory;
    // [SerializeField] private PlayerController controller;
    [SerializeField] private Garment garment;

    private void Start()
    {
        camera = GameObject.Find("WorkshopCam");
        Inventory = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        sewingSFX = GameObject.Find("sewing-machine_sfx").GetComponent<AudioSource>();
    }

    void Awake()
    {
        startTransform = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        // controller.dragging = true;
        canDrag = true;
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            transform.position = Input.mousePosition;
        }
        // controller.dragging = true;
        RaycastHit hit;
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out hit) && hit.transform.tag == "Hole" && gameObject.tag == "Patch")
        {
            if (Inventory.itemList.item3Quantity > 0)
            {
                //Decrease number of patches in the inventory
                Inventory.itemList.item3Quantity--;
                List<Transform> anchors = new List<Transform>();
                foreach (Transform child in hit.transform)
                { 
                    anchors.Add(child); 
                    // Debug.Log(anchors);
                }
                if (canDrag) 
                { 
                    foreach (var anchor in anchors) 
                    { 
                        var CornerInst = Instantiate(Corner, anchor.position, anchor.rotation, GameObject.FindWithTag("Garment").transform); 
                        CornerInst.tag = "Corner";
                        // CornerInst.transform.parent = anchor;
                        // // Debug.Log(CornerInst);
                    }
                    garment = GameObject.FindWithTag("Garment").GetComponent<Garment>(); 
                    Instantiate(garment.Patches[Random.Range(0, garment.Patches.Length)], hit.transform.position, 
                        hit.transform.rotation, garment.transform);
                    soundscount++;
                    if (soundscount == 2)
                    {
                        soundscount = 0;
                        sewingSFX.Play();
                    }
                    
                    
                    canDrag = false; 
                    hit.transform.gameObject.SetActive(false);
                }
                var  holes = GameObject.FindWithTag("Garment").GetComponent<Garment>().Holes; 
                if (holes != null) 
                { 
                    for (int i = holes.Count - 1; i >= 0; i--) 
                    { 
                        if (holes[i] == hit.transform.gameObject) 
                        { 
                            // Debug.Log("Detected");
                            Destroy(hit.transform.gameObject); 
                            holes.RemoveAt(i);
                        }
                    }
                }
            }
            else
            {
                //Add UI feedback
                Debug.Log("Not enough materials");
            }
        }
        if (Physics.Raycast(r, out hit) && hit.transform.tag == "Corner" && gameObject.tag == "Needle")
        {
            if (Inventory.itemList.item1Quantity > 0 && Inventory.itemList.item2Quantity > 0)
            {
                Destroy(hit.transform.gameObject);
                //Decrease number of threads and needles
                Inventory.itemList.item1Quantity--;
                Inventory.itemList.item2Quantity--;
            }
            else
            {
                //Add UI feedback
                Debug.Log("Not enough materials");
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // controller.dragging = false;
        transform.position = startTransform;
        canDrag = true;
    }
}
