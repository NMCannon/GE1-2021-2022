using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AITank : MonoBehaviour {

    public int loops = 10;
    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 5;
    public Transform player;
    public int count = 0;

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
    void Awake()
    {
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
                float z = Mathf.Cos(angle) * radius * 3;
                waypoints.Add(new Vector3(x, 0.5f, z));
            }
        }
        
    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[count], speed * Time.deltaTime);
        StartCoroutine(waiter());
        

        // Task 4
        // Put code here to check if the player is in front of or behine the tank
        // float dot = Vector3.Dot(transform.forward, player.position);
        //float theta2 = Mathf.Acos(dot) * Mathf.Rad2Deg;
        //Debug.Log((dot > 0) ? "in front" : "behind");
        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:
        GameManager.Log("Hello from th AI tank");
    }

    IEnumerator waiter()
    {
        //Wait for 6 seconds
        yield return new WaitForSeconds(6);
        Debug.Log(waypoints[count]);
        count++;
    }
}
