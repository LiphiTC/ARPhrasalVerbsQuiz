using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{

    public float maxRotationSpeed = 50f;
    public float rotationAcceleration = 5f;
    public float minRotationAngle = -60f;
    public float maxRotationAngle = 60f;

    private float currentRotationSpeed = 0f;
    private float currentRotationAcceleration = 0f;
    private bool clockwise = true;
    private GameManager _gameManager;


    public void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (clockwise)
        {
            currentRotationAcceleration = rotationAcceleration;
        }
        else
        {
            currentRotationAcceleration = -rotationAcceleration;
        }

        if (currentRotationSpeed < maxRotationSpeed)
        {
            currentRotationSpeed += currentRotationAcceleration;
        }
        else
        {
            currentRotationSpeed = maxRotationSpeed;
        }

        RotateObjectSmoothly(Vector3.up, currentRotationSpeed, clockwise);
    }

    void RotateObjectSmoothly(Vector3 axis, float speed, bool clockwise)
    {
        float rotationAngle = speed * Time.deltaTime;
        if (!clockwise)
        {
            rotationAngle = -rotationAngle;
        }
        transform.Rotate(axis, rotationAngle, Space.World);

        // Check if we should change direction
        float currentAngle = transform.eulerAngles.y;
        
        if (currentAngle < _gameManager.TappedRotation.eulerAngles.y + minRotationAngle || currentAngle > _gameManager.TappedRotation.eulerAngles.y + maxRotationAngle)
        {
            clockwise = !clockwise;
        }
    }
}
