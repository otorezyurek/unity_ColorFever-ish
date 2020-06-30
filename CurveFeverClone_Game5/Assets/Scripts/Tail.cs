using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.Experimental.GraphView;

public class Tail : MonoBehaviour
{
    LineRenderer lr;
    EdgeCollider2D ec;
    List<Vector2> points;
    public Transform head;
    public float pointSpacing;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        ec = GetComponent<EdgeCollider2D>();
        points = new List<Vector2>();

        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(points.Last(), head.position) > pointSpacing)
		{
            SetPoint();
        }
        
    }

    public void SetPoint()
	{
        if (points.Count > 1)
        {
            ec.points = points.ToArray<Vector2>();
        }

        points.Add(head.position);

        lr.positionCount = points.Count;
        lr.SetPosition(points.Count - 1, head.position);

       
        
	}
}
