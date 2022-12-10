using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] AudioSource buttonSound;

    public void showLevelMenu(){
        levelMenu.SetActive(true);
        mainMenu.SetActive(false);
        buttonSound.Play();
    }
    public void showMainMenu()
    {
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
        buttonSound.Play();
    }
    public void Quit()
    {
        buttonSound.Play();
        Application.Quit();
    }
}
