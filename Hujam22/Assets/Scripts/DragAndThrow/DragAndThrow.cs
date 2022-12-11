using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndThrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float power = 10f;
    [SerializeField] Vector2 minPower;
    [SerializeField] Vector2 maxPower ;

    [SerializeField] AudioSource rocketSound;
    [SerializeField] ParticleSystem fire;
    [SerializeField] Transform lineStart;

    private TrajectoryLine tl;
    private Rigidbody2D rb;
    private Camera cam;

    public int fuel=2;
    Vector2 force;
    Vector2 direction;
    Vector3 startPoint;
    Vector3 endPoint;

    private Animator animator;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        tl = GetComponent<TrajectoryLine>();
        rb = gameObject.GetComponent < Rigidbody2D >() ;
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
           
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;

        }

        if (Input.GetMouseButton(0)) {

            fire.Stop();
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            Vector3 linePoint= lineStart.position + (startPoint -currentPoint);
            // tl.RenderLine(startPoint, currentPoint);
            direction = linePoint - lineStart.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            tl.RenderLine(linePoint,lineStart.position);
            transform.rotation = rotation;

        }
        if (Input.GetMouseButtonUp(0))
        {
           
            if (fuel > 0)
            {
               
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;

                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));

                //Animation
                animator.SetBool("launch",true);
                
                if (force.magnitude > 0.1) {
                    rb.velocity = new Vector2(0, 0);
                    fire.Play();
                    rb.AddForce(force.magnitude * direction * power, ForceMode2D.Impulse);
                    fuel--;
                    rocketSound.Play();
                }
                
                
            }
            tl.EndLine();
            
        }
    }
}
