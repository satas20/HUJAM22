using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject rocket;
    DragAndThrow dAT;
    TrajectoryLine tL;
    [SerializeField] AudioSource buttonSound;


    private void Awake()
    {
        rocket=GameObject.FindGameObjectWithTag("rocket");
        dAT = rocket.GetComponent<DragAndThrow>();
        tL = rocket.GetComponent<TrajectoryLine>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            dAT.enabled = false;
            tL.enabled = false;
        }
        if (Input.GetKeyDown("r")){
            Restart();
        }
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        dAT.enabled = true;
        tL.enabled = true;
        buttonSound.Play();
    }
    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");
        buttonSound.Play();
    }
    public void Countiniue()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        dAT.enabled = true;
        tL.enabled = true;
        buttonSound.Play();
    }
    public void Quit() {
        Application.Quit();
    }



}
