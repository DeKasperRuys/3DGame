using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtendedCameraWalkerController : CameraWalkerController
{
    float defaultMovementSpeed;
    public float sprintingSpeed;
    public KeyCode sprintingKeyCode = KeyCode.LeftShift;
    public bool IsSprinting { get; protected set; }
    public UnityEvent onSprintBegan = new UnityEvent();
    public UnityEvent onSprintEnded = new UnityEvent();

    protected override void Setup()
    {

        base.Setup();
        defaultMovementSpeed = movementSpeed;
    }

    void LateUpdate()
    {
        sprintingSpeed = defaultMovementSpeed * 2;
        var wasSprinting = IsSprinting;
        IsSprinting = Input.GetKey(sprintingKeyCode);
        movementSpeed = IsSprinting ? sprintingSpeed : defaultMovementSpeed;
        if (!wasSprinting && IsSprinting) onSprintBegan.Invoke();
        if (wasSprinting && !IsSprinting) onSprintEnded.Invoke();
    }
}

