using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    private int currentwaypointindex = 0;
    [SerializeField]private float speed =2f;
    
    private void Update()
    {
        if (Vector2.Distance(WayPoints[currentwaypointindex].transform.position, transform.position) < .1f)
        {

            currentwaypointindex++;
            if(currentwaypointindex >= WayPoints.Length)
            {
                currentwaypointindex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[currentwaypointindex].transform.position, Time.deltaTime * speed);
    }
}
