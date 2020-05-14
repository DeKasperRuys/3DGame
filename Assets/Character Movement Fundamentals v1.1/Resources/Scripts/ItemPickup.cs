using System.Collections;
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
        /*
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, ray_Range))
        {
            if (hit.transform.name == "Item")
            {
                Debug.Log("swaaag");
                if (Input.GetKeyDown(interact))
                {
                    Destroy(hit.transform.parent.gameObject);
                }
            }
        }
        */




            Ray ray_Cast = camera.ScreenPointToRay(new Vector2(Screen.width /2, Screen.height/2));
            RaycastHit ray_Hit;
        
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
                MessagePanel.SetActive(false);
            }
            
        }



        }
}
