using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController: MonoBehaviour {

    [SerializeField] float Speed = 15f;
    [SerializeField] float xClamp = 10f;
    [SerializeField] float yClamp = 6f;

    [SerializeField] float positionXFactor = -1.5f;
    [SerializeField] float controlXFactor = -20f;
    [SerializeField] float positionYFactor = 1.5f;
    [SerializeField] float controlZFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }



    private void ProcessRotation()
    {
        float xRot = transform.localPosition.y * positionXFactor + yThrow * controlXFactor;
        float yRot = transform.localPosition.x * positionYFactor;
        float zRot = xThrow * controlZFactor;
        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float xPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xPos, -xClamp, xClamp);

        float yOffset = yThrow * Speed * Time.deltaTime;
        float yPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(yPos, -yClamp, yClamp);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
