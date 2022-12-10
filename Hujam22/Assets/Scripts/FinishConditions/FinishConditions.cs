using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishConditions : MonoBehaviour
{
    private Camera camera;
    private string sceneName;
    [SerializeField] private float magnitude;
    [SerializeField] private float duration;
    private bool isDangerousObject;
    private float elapsed;
    [SerializeField] ParticleSystem crash;

    private void Awake()
    {
        isDangerousObject = false;
        elapsed = 0;

    }
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDangerousObject)
        {
            ShakeCamera();
        }
    }

    private void ShakeCamera()
    {
        if(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camera.transform.position += new Vector3(x, y);
            elapsed += Time.deltaTime;
           // Debug.Log(elapsed);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "dangerousObject")
        {
            gameObject.GetComponent<DragAndThrow>().enabled = false;
            gameObject.GetComponent<TrajectoryLine>().enabled = false;
            crash.Play();
            isDangerousObject=true;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
        else if(collision.gameObject.tag == "fuel")
        {
            this.gameObject.GetComponent<DragAndThrow>().fuel += 1;
        }
        else if (collision.gameObject.tag == "finish")
        {
            Debug.Log(int.Parse(sceneName)+1);
            SceneManager.LoadScene(int.Parse(sceneName)+1);
        }
    }


}
