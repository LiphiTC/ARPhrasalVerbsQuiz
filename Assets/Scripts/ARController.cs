using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{

    public GameObject ObjectToPlace;

    public ARRaycastManager RayCastManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var touches = new List<ARRaycastHit>();

            RayCastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (touches.Count != 0)
            {
                ObjectToPlace.transform.SetPositionAndRotation(touches[0].pose.position, touches[0].pose.rotation);

                ObjectToPlace.transform.Rotate(0, 180, 0);


            }
        }


    }
}
