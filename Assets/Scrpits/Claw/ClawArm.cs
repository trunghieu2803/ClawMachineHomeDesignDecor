using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawArm : MonoBehaviour
{
    public event Action OnOpenClawtArm, OnCloseClawArm;
    ClawMove _clawMove;

    private void Start()
    {
        _clawMove = GetComponentInParent<ClawMove>();
    }
    private void Update()
    {
        if (_clawMove.CheckIsClaw)
        {
            OnOpenClawtArm?.Invoke();
        }
        else OnCloseClawArm?.Invoke();
    }


    
}
