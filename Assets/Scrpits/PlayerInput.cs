using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public Vector2 _moveMent { get; private set; }
    [SerializeField] PolygonCollider2D _poly;
    public bool _checkClickStick { get; private set; }
    public event Action<Vector2> OnMoveStick;
    void Start()
    {
        _poly = GetComponentInChildren<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        GetMoveStick();
    }
    void GetMoveStick()
    {
        ClickStick();
        ClosedClickStick();
        if (_checkClickStick)
        {
            _moveMent = GetPos();
            OnMoveStick?.Invoke(_moveMent);
        }
    }



    void ClosedClickStick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _checkClickStick = false;
            _moveMent = Vector2.zero;
        }
    }
    void ClickStick()
    {
        if (Input.GetMouseButtonDown(0))
            if (_poly.bounds.Contains(GetPos()))
                _checkClickStick = true;
    }

    private Vector2 GetPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
