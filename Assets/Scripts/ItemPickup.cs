using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPickup : MonoBehaviour
{
    //PLAYER CLASS VOOR INVENTORY TUTORIAL


    public GameObject MessagePanel;
    public new Camera camera;
    public float ray_Range = 3f;
    public KeyCode interact;

    public GameObject endPortalSpawn;
    public Text changeText;
    public int collectedCrystals=0;
    public bool pickedUp;

    //Inventory
    public InventoryObject inventory;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
            Ray ray_Cast = camera.ScreenPointToRay(new Vector2(Screen.width /2, Screen.height/2));
            RaycastHit ray_Hit;

        MessagePanel.SetActive(false);

        if (Physics.Raycast(ray_Cast, out ray_Hit, ray_Range))
            {
            
            if (ray_Hit.collider.tag == "Item")
            {
             MessagePanel.SetActive(true);
                if (Input.GetKeyDown(interact))
                {
                    
                    GameObject itempickedUp = ray_Hit.collider.gameObject;
                    var item = itempickedUp.GetComponent<Item>();
                    if (item)
                    {
                        inventory.AddItem(item.item, 1);
                    }
                    collectedCrystals++;
                    changeText.text = "Collect all " + collectedCrystals + "/8 crystals to open a portal.";
                    Destroy(itempickedUp);
                    if (collectedCrystals == 8)
                    {
                        changeText.text = "All crystals are collected. Go to the open field to summon a portal";
                        endPortalSpawn.SetActive(true);
                    }
                }
                
            }

        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

   
}
