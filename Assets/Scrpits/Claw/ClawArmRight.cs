using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawArmRight : MonoBehaviour
{
    [SerializeField] int clawOpenAngle = 35;
    ClawArm _clawArm;
    private void Awake()
    {
        _clawArm = GetComponentInParent<ClawArm>();
    }

    private void Start()
    {
        _clawArm.OnOpenClawtArm += OpenRightClaw;
        _clawArm.OnCloseClawArm += CloseRightClaw;
    }
    public void OpenRightClaw()
    {
        if (this.transform.eulerAngles.z <= clawOpenAngle)
        {
            this.transform.Rotate(0, 0, 1);
        }
    }
    
    public void CloseRightClaw()
    {
        if (this.transform.eulerAngles.z - 1 > 0)
        {
            this.transform.Rotate(0, 0, -1);
        }
    }
}
