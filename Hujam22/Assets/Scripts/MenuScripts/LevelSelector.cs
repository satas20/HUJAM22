using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
   
    public int level;
    [SerializeField] AudioSource buttonSound;
    GameObject mainMenu;

    private Camera mCam;
    private WaitForSeconds mSeconds = new WaitForSeconds(0.01f);
    private Vector3 mPos;
    private void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        buttonSound = mainMenu.GetComponent<AudioSource>();
        mCam = Camera.main;
    }
    public void loadLevel() 
    {
        buttonSound.Play();
        StartCoroutine(CineCam());
    }

    IEnumerator CineCam()
    {
        while (true)
        {
            switch (level)
            {
                case 1:

                    mCam.transform.position = new Vector3(1.4f, 0.6f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 2:

                    mCam.transform.position = new Vector3(2.64f, 0.6f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 3:

                    mCam.transform.position = new Vector3(3.9f, 0.6f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 4:

                    mCam.transform.position = new Vector3(5.14f, 0.6f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 5:

                    mCam.transform.position = new Vector3(6.4f, 0.6f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 6:

                    mCam.transform.position = new Vector3(1.4f, -0.65f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 7:

                    mCam.transform.position = new Vector3(2.64f, -0.65f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 8:

                    mCam.transform.position = new Vector3(3.9f, -0.65f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 9:

                    mCam.transform.position = new Vector3(5.14f, -0.65f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                case 10:

                    mCam.transform.position = new Vector3(6.4f, -0.65f, -10);
                    mCam.orthographicSize -= 0.05f;

                    yield return mSeconds;
                    break;
                default:
                    break;
            }
            if(mCam.orthographicSize <= 0.06f)
            {
                SceneManager.LoadScene(level);
                break; 
            }
        }
        
        yield return 0;
    }

}


