using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMovement : MonoBehaviour
{
    private float timeCounter;
    [SerializeField] private float speed;
    [SerializeField] private float width;
    [SerializeField] private float height;
    private Vector2 distance;
    private Vector3 parentPosition;

    //Line
    private LineRenderer line;
    [SerializeField] private int segments;

    private void Awake()
    {
        timeCounter = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        parentPosition = transform.parent.position;

        line = gameObject.GetComponent<LineRenderer>();

        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
    }

    private void FixedUpdate()
    {
        OrbitalMovementFunc();
        CreatePoints();
    }

    private void OrbitalMovementFunc()
    {
        timeCounter += Time.fixedDeltaTime * speed;

        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;

        distance.x = parentPosition.x + x;
        distance.y = parentPosition.y + y;

        transform.position = distance;
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * width;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * height;

            line.SetPosition(i, (parentPosition - transform.position) + new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }
}
