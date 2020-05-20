using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtendedCameraWalkerController : CameraWalkerController
{
    float defaultMovementSpeed;
    public Vector3 MomentumDebug, debugDirection2 = Vector3.zero;
    private CameraController camReference;
    public float slideForce = 1000;
    public float sprintingSpeed, crouchingSpeed, debugMagnitude;

    protected override void Setup()
    {
        Cursor.visible = false;
        base.Setup();
        defaultMovementSpeed = movementSpeed;
        camReference = GetComponentInChildren<CameraController>();
    }

    void LateUpdate()
    {
        debugDirection2 = GetVelocity();
        debugMagnitude = debugDirection2.magnitude;
        if (mover.IsGrounded())
        {
            sprintingSpeed = defaultMovementSpeed * 2;
            crouchingSpeed = defaultMovementSpeed / 2;

            if (Input.GetKeyDown(KeyCode.LeftControl))
                StartCrouch();

            if (Input.GetKeyUp(KeyCode.LeftControl))
                StopCrouch();

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movementSpeed = sprintingSpeed;
                camReference.SetFOV(Mathf.Lerp(90, 110, Time.deltaTime * 20f));
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                movementSpeed = defaultMovementSpeed;
                camReference.SetFOV(90);
            }
        }
    }

    private void StartCrouch()
    {

        camReference.transform.localPosition = Vector3.up * -.5f;

        if (debugMagnitude > 6)
        {
            camReference.SetFOV(Mathf.Lerp(90, 110, Time.deltaTime * 20f));
            AddMomentum(debugDirection2 / 10 * slideForce);
            movementSpeed = crouchingSpeed;
        }
        movementSpeed = crouchingSpeed;

    }

    private void StopCrouch()
    {
        camReference.SetFOV(90);
        movementSpeed = defaultMovementSpeed;
        camReference.transform.localPosition = Vector3.up * .5f;
    }
}

