using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Vector2 distance;
    [SerializeField] private float gravityForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "rocket")
        {
            distance = this.transform.position - collision.transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(distance * gravityForce, ForceMode2D.Force);
        }
    }
}
