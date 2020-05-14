﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject MessagePanel;
    public Camera camera;
    public float ray_Range = 1f;
    public KeyCode interact;

    //RaycastHit hit;

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
                Destroy(ray_Hit.collider.gameObject);
                }
                
            }
            else
            {

            }

        }
    }
}
