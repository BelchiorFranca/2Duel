using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed;
    public int startingPoint;
    public Transform[] points;

    private float distanceError = 0.02f;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance from the next point
        if (Vector2.Distance(transform.position, points[i].position) < distanceError){
            i++; // Increase point index
            if (i == points.Length){
                i = 0; // Reset Index
            }
        }

        transform.position = Vector2.MoveTowards(
            transform.position, points[i].position, speed * Time.deltaTime
        );
    }
}
