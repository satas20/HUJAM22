using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystem : MonoBehaviour
{
    private Vector3 PortalA;
    private Vector3 PortalB;
    private WaitForSeconds waitforseconds = new WaitForSeconds(0.5f);

    private void Start()
    {
        PortalA = this.transform.parent.transform.GetChild(0).gameObject.transform.position;
        PortalB = this.transform.parent.transform.GetChild(1).gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "rocket")
        {
            if(this.gameObject.name == "PortalA")
            {
                StartCoroutine(CheckEnablePortal(1));
                collision.gameObject.transform.position = PortalB;
            }
            else
            {
                StartCoroutine(CheckEnablePortal(0));
                collision.gameObject.transform.position = PortalA;
            }
        }
    }

    IEnumerator CheckEnablePortal(int i)
    {
        this.transform.parent.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = false;
        yield return waitforseconds;
        this.transform.parent.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
