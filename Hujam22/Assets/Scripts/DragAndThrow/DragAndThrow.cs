using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndThrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float power = 10f;
    [SerializeField] Vector2 minPower;
    [SerializeField] Vector2 maxPower ;

    private TrajectoryLine tl;
    private Rigidbody2D rb;
    private Camera cam;

    public int fuel=2;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;


    private void Start()
    {
        tl = GetComponent<TrajectoryLine>();
        rb = gameObject.GetComponent < Rigidbody2D >() ;
        cam = Camera.main;
    }
    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
           
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;

        }

        if (Input.GetMouseButton(0)) {
            

            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            Vector3 linePoint=  transform.position + (startPoint -currentPoint);
            // tl.RenderLine(startPoint, currentPoint);
            Vector2 direction = linePoint - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
            tl.RenderLine(linePoint,transform.position);

            
        }
        if (Input.GetMouseButtonUp(0))
        {
           
            if (fuel > 0)
            {
                rb.velocity = new Vector2(0, 0);
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;

                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);

                fuel--;
            }
            tl.EndLine();
            
        }
    }
}
