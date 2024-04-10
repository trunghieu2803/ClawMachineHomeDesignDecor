using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawArmLeft : MonoBehaviour
{
    [SerializeField] float clawOpenAngle = 35f;
    ClawArm _clawArm;
    private void Awake()
    {
        _clawArm = GetComponentInParent<ClawArm>();
    }

    private void Start()
    {
        _clawArm.OnOpenClawtArm += OpenLeftClaw;
        _clawArm.OnCloseClawArm += CloseLeftClaw;
    }

    public void OpenLeftClaw()
    {
        if (361 - this.transform.eulerAngles.z <= clawOpenAngle)
        {
            this.transform.Rotate(0, 0, -1);
        }
    }

    public void CloseLeftClaw()
    {
        if (360 - this.transform.eulerAngles.z > 1)
        {
            this.transform.Rotate(0, 0, 1);
        }
    }

}
