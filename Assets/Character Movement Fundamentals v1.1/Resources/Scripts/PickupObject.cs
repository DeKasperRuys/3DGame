using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject MessagePanel;
    public KeyCode lootKey = KeyCode.E;
    private bool pickUpAllowed;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag=="Player")
        {
            //Destroy(gameObject);
            MessagePanel.SetActive(true);
            pickUpAllowed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            MessagePanel.SetActive(false);
            pickUpAllowed = false;
        }
        
    }
    private void Update()
    {
        if (pickUpAllowed && (Input.GetKey(lootKey)))
        {
            Destroy(gameObject);
            MessagePanel.SetActive(false);
        }
    }
}
