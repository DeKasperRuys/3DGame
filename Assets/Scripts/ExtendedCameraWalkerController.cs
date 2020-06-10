using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtendedCameraWalkerController : CameraWalkerController
{
    
    float defaultMovementSpeed;
    public Vector3 MomentumDebug, debugDirection2 = Vector3.zero;
    private CameraController camReference;
    public float slideForce = 15;
    public float sprintingSpeed, crouchingSpeed, debugMagnitude;
    //private bool isSliding = false;
    


    public float TargetFOV = 110f;
    public float Speed = 1f;
    protected Camera cam;


    //Voorlopig

    public Transform teleportTarget;
    public GameObject thePlayer;


    protected override void Setup()
    {
        
        Cursor.visible = false;
        base.Setup();
        defaultMovementSpeed = movementSpeed;
        camReference = GetCameraController();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        { thePlayer.transform.position = teleportTarget.transform.position; }

            debugDirection2 = GetMovementVelocity();
        debugMagnitude = debugDirection2.magnitude;
        if (mover.IsGrounded())
        {
            sprintingSpeed = defaultMovementSpeed * 1.45f;
            crouchingSpeed = defaultMovementSpeed / 2;

            if (Input.GetKeyDown(KeyCode.LeftControl))
                StartCrouch();

            if (Input.GetKeyUp(KeyCode.LeftControl))
                StopCrouch();

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movementSpeed = sprintingSpeed;

                camReference.SetFOV(Mathf.SmoothStep(110, 90, 10 * Time.deltaTime));
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
       // transform.localPosition = new Vector3((transform.localPosition.x), (transform.localPosition.y - 0.64999f), (transform.localPosition.z));
        //transform.localScale = new Vector3(1, 0.5f, 1);
        
        camReference.transform.localPosition = Vector3.up * -.5f;
        Vector3 momentum = GetMomentum();
        if (debugMagnitude > 6 && momentum.x < 0.5 && momentum.z < 0.5)
            {
            
            camReference.SetFOV(Mathf.Lerp(90, 110, Time.deltaTime * 20f));
                AddMomentum(debugDirection2 / 10 * slideForce);
                movementSpeed = crouchingSpeed;

            }
        
        
        movementSpeed = crouchingSpeed;
        
    }

    private void StopCrouch()
    {
        
       // transform.localScale = new Vector3(1, 1, 1);
        camReference.SetFOV(90);
        movementSpeed = defaultMovementSpeed;
        camReference.transform.localPosition = Vector3.up * .5f;
    }
}

