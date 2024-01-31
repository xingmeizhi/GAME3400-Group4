using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float speed = 2f;
    private GameObject wallObject;
    private bool shouldMove = false;

    void Start()
    {
        wallObject = GameObject.FindWithTag("wall");
        if (wallObject == null)
        {
            Debug.LogError("No object with tag 'wall' found");
        }
    }

    void Update()
    {
        if (shouldMove)
        {
            MoveTowardsWall();
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }

    private void MoveTowardsWall()
    {
        if (wallObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallObject.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, wallObject.transform.position) < 0.001f)
            {
                Destroy(gameObject);
            }
        }
    }
}
