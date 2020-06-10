using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{

    public GameObject MessagePanel;

    void OnTriggerEnter(Collider other)
    {
        MessagePanel.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        MessagePanel.SetActive(false);
    }
}
