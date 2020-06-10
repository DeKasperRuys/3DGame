using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMovement : MonoBehaviour {


	Animator animator;
	bool doorOpen;
	public AudioClip DoorSound;
    public GameObject notEnoughCrystals;
    private ItemPickup crystals;
    private float crystalCount;


	void Start () {

		doorOpen = false;
		animator = GetComponent<Animator> ();


	}

	void OnTriggerEnter(Collider col) {

		if(col.gameObject.tag == "Player"){

            crystals = col.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<ItemPickup>();
            crystalCount = crystals.collectedCrystals;
            if (crystalCount == 2 ||  crystalCount > 2) { 
			gameObject.GetComponent<AudioSource>().PlayOneShot (DoorSound);
			doorOpen = true;
			DoorControl ("Open");
            transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                notEnoughCrystals.SetActive(true);
            }

        }
	}


	void OnTriggerExit (Collider col ){

        notEnoughCrystals.SetActive(false);
        if (doorOpen){
            gameObject.GetComponent<AudioSource>().PlayOneShot (DoorSound);
			doorOpen = false;
			DoorControl ("Close");
            

        }
	}


	void  DoorControl (string direction){

		animator.SetTrigger (direction);

	  }

	}