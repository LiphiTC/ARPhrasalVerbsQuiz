using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowUp : MonoBehaviour
{
    public float growthDuration = 7f; // the duration over which the object should grow
    public float finalScale = 1.2f; // the final scale that the object should reach

    private Vector3 initialScale; // the initial scale of the object

    void Start()
    {
        initialScale = transform.localScale; // record the initial scale of the object
        StartCoroutine(GrowObject()); // start the coroutine to grow the object
    }

    IEnumerator GrowObject()
    {
        while (true)
        {

            float elapsedTime = 0f; // the time elapsed since the coroutine started

            while (elapsedTime < growthDuration)
            {
                // Calculate the new scale of the object using a lerp function
                float t = elapsedTime / growthDuration;
                Vector3 newScale = Vector3.Lerp(initialScale, Vector3.one * finalScale, t);

                // Set the scale of the object to the new scale
                transform.localScale = newScale;

                // Wait for the next frame
                yield return null;

                // Update the elapsed time
                elapsedTime += Time.deltaTime;
            }

            // Set the final scale of the object
            transform.localScale = initialScale;
        }

    }

}
