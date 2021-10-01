using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public int loops = 10;
    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;    

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            // Task 1
            // Put code here to draw the gizmos
            // Use sin and cos to calculate the positions of the waypoints 
            // You can draw gizmos using
            // Gizmos.color = Color.green;
            // Gizmos.DrawWireSphere(pos, 1);

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }

    // Use this for initialization
    void Awake () {
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List

        for (int i = 0; i < loops; i++)
        {
            int num = (int)(Mathf.PI * 2.0f * i * radius);
            float theta = (2.0f * Mathf.PI) / (float)num;

            for (int j = 0; j < num; j++)
            {
                float angle = theta * j;
                float x = Mathf.Sin(angle) * radius * 3;
                float y = Mathf.Cos(angle) * radius * 3;
                waypoints.Add(new Vector3(x, y, 0));
            }
        }
    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        for(int z=0; z<10;z++)
        {
            transform.Translate(waypoints[z] * 10 * Time.deltaTime);
        }
        

        // Task 4
        // Put code here to check if the player is in front of or behine the tank
        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:
        GameManager.Log("Hello from th AI tank");
    }
}
