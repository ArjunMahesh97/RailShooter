﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] float Speed = 40f;
    [SerializeField] float xClamp = 10f;
    [SerializeField] float yClamp = 7f;

    [SerializeField] float xFactor = -1.5f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float xRot = transform.localPosition.y * xFactor;
        float yRot = 0f;
        float zRot = 0f;
        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }

    private void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float xPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xPos, -xClamp, xClamp);

        float yOffset = yThrow * Speed * Time.deltaTime;
        float yPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(yPos, -yClamp, yClamp);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
