using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float speed = 1f;
    public AudioSource audioSource;
    private Vector3 startPosition;
    private GameObject targetObject;
    private bool isAtStartPosition = false;

    public bool IsAtStartPosition
    {
        get { return isAtStartPosition; }
    }

    void Start()
    {
        startPosition = transform.position;
        targetObject = GameObject.FindWithTag("mouse");

        if (targetObject != null)
        {
            StartCoroutine(MoveToTarget());
        }
        else
        {
            Debug.LogError("No object with tag 'mouse' found");
        }
    }

    IEnumerator MoveToTarget()
    {
        Vector3 targetPosition = targetObject.transform.position;

        while (Vector3.Distance(transform.position, targetPosition) > 1.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(MoveToPosition(startPosition));
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

        isAtStartPosition = true;
        audioSource.Play();
        GameObject mouseObject = GameObject.FindWithTag("mouse");
        if (mouseObject != null)
        {
            MouseMove mouseMove = mouseObject.GetComponent<MouseMove>();
            if (mouseMove != null)
            {
                mouseMove.StartMoving();
            }
        }
    }
}
