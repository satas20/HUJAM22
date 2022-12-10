using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
   
    public int level;
    [SerializeField] AudioSource buttonSound;
    GameObject mainMenu;
    private void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        buttonSound = mainMenu.GetComponent<AudioSource>();
    }
    public void loadLevel() 
    {
        buttonSound.Play();
        SceneManager.LoadScene(level);
    }
}
