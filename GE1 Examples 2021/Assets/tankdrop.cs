using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankdrop : MonoBehaviour
{
    public GameObject aiTank2;

    System.Collections.IEnumerator DropTank()
    {
        int maxtankCount = 5;
        while (true)
        {

            {
                GameObject tank = GameObject.Instantiate<GameObject>(aiTank2);
                tank.transform.position = new Vector3(0, 10, 0);
                tank.AddComponent<Rigidbody>();
                tank.tag = "tank";
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void OnEnable()
    {
        StartCoroutine(DropTank());
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("tank");
        Debug.Log(tanks.Length);

    }
}
