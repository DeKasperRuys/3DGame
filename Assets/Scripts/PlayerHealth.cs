using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public GameManager manager;
    public Slider healthBar;
    public float health = 100f;

    public GameObject thePlayer;
    private Vector3 respawnPoint;

    private void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float amnt)
    {
        health -= amnt;
        if (health <= 0f)
        {
            thePlayer.transform.position = respawnPoint;

            //manager.GameOver();
            health = 100f;
        }
        float _h = Mathf.Clamp(health, 0, 100f);
        healthBar.value = _h;
    }


    public void setSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
