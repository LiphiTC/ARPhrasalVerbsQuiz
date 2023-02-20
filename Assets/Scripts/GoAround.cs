using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoAround : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject SmileBody;
    public SlimeAnimationState currentState;

    public Animator animator;

    public Transform[] waypoints; // an array of transforms representing the waypoints
    public float movementSpeed = 0.6f; // the speed at which the object will move
    public float stoppingDistance = 0.1f; // the distance at which the object will stop moving
    private int currentWaypoint = 0; // the current waypoint the object is moving towards

    void Update()
    {

        // Calculate the direction to the current waypoint
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;

        // Rotate the object to face the current waypoint
        transform.LookAt(waypoints[currentWaypoint]);

        // Move forward in the direction the object is facing
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        // If the object is close enough to the current waypoint, move to the next waypoint
        if (direction.magnitude <= stoppingDistance)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                transform.position = waypoints[0].position;
                currentWaypoint = 0; 
            }
        }
    }

}
