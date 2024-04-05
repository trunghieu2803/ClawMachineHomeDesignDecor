using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ClawMove : MonoBehaviour
{
    [SerializeField] float _speed = 0, maxleft, maxRight;
    PlayerInput _PlayerInput;
    bool checkMaxLR;
    float posClaw, _MoveX = 0;
    GameObject _target;
    void Awake()
    {
        _target = GameManager.Instance.Lever;
        
    }

    private void Start()
    {
        _PlayerInput = _target.GetComponent<PlayerInput>();
        
    }

    private void Update()
    {
        OnMoveClaw();
    }

    void OnMoveClaw()
    {
        
        posClaw = this.transform.position.x;
        _MoveX = _PlayerInput._moveMent.x == 0 ? 0 : _PlayerInput._moveMent.x > 0 ? 1 : -1;
        if ((posClaw <= maxleft && _MoveX < 0) || (posClaw >= maxRight && _MoveX > 0)) return;
        this.transform.position += new Vector3(_MoveX * _speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
