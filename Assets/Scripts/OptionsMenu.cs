using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public GameObject menuMain;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SelectLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
