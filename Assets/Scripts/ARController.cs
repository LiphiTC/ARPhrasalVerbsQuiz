using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{

    public ARRaycastManager RayCastManager;    
    private GameManager _gameManager;

    public void Start() {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var touches = new List<ARRaycastHit>();

            RayCastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (touches.Count != 0)
            {
    
                _gameManager.Tapped(touches[0].pose.position, touches[0].pose.rotation);
            }
        }
    }


}
