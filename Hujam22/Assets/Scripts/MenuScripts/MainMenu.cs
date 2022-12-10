using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject mainMenu;


    public void showLevelMenu(){
        levelMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void showMainMenu()
    {
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
