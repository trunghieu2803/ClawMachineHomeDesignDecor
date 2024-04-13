using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawArmLeft : MonoBehaviour
{
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
        if (this.transform.eulerAngles.z >= 326)
        {
            this.transform.Rotate(0, 0, -1);
        }
    }

    public void CloseLeftClaw()
    {
        if (this.transform.eulerAngles.z < 358)
        {
            this.transform.Rotate(0, 0, 1);
        }
    }

}
