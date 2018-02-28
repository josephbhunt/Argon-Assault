using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 10f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 10f;
    [Tooltip("In m")] [SerializeField] float xRange = 3f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;

    [SerializeField] float pitchFactor = -3.3f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float yawFactor = 5f;
    [SerializeField] float rollFactor = -10f;

    float yThrow;
    float xThrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInputs();
        ApplyHorizontalMovement();
        ApplyVerticalMovement();
        ApplyRotation();
    }

    private void GetInputs()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
    }

    private void ApplyRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = rollFactor * xThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ApplyVerticalMovement()
    {
        float yOffSetThisFrame = yThrow * ySpeed * Time.deltaTime;
        float newLocalYPosition = Mathf.Clamp(transform.localPosition.y + yOffSetThisFrame, -yRange, yRange);
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            newLocalYPosition,
            transform.localPosition.z
        );
    }

    private void ApplyHorizontalMovement()
    {
        float xOffSetThisFrame = xThrow * xSpeed * Time.deltaTime;
        float newLocalXPosition = Mathf.Clamp(transform.localPosition.x + xOffSetThisFrame, -xRange, xRange);
        transform.localPosition = new Vector3(
            newLocalXPosition,
            transform.localPosition.y,
            transform.localPosition.z
        );
    }
}
