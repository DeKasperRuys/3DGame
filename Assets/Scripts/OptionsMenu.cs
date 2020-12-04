using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public GameObject menuMain;
    public GameObject Level1, Level2;
    private bool isLevel1Selected = false;
    private bool isLevel2Selected = false;
    private void Start()
    {
        Cursor.visible = true;
    }

    public void BackToMenu()
    {
        menuMain.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SelectLevel1()
    {
        isLevel1Selected = true;
        isLevel2Selected = false;
        Level1.SetActive(true);
        Level2.SetActive(false);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SelectLevel2()
    {
        isLevel1Selected = false;
        isLevel2Selected = true;
        Level2.SetActive(true);
        Level1.SetActive(false);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void StartLevel()
    {
        if (isLevel1Selected)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (isLevel2Selected)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
