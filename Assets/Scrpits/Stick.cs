using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Stick : MonoBehaviour
{
    public PlayerInput _playerInput;
    [SerializeField] int maxAngle;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    private void Start()
    {
        _playerInput.OnMoveStick += Move;
    }

    void Move(Vector2 target)
    {
        Quaternion q = this.transform.rotation;
        Vector2 dir = target - (Vector2)this.transform.position;
        int angle = (Math.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90).ConvertTo<int>();
        angle = dir.x < 0 && dir.y < 0 && angle < 0 ? maxAngle : dir.x > 0 && dir.y < 0 && angle < 0 ? -maxAngle : angle;
        if (angle <= maxAngle && angle >= -maxAngle)
        {
            q.eulerAngles = new Vector3(0, 0, angle);
            this.transform.rotation = q;
        }
    }


}
