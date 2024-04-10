using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
public class ClawMove : MonoBehaviour
{
    [SerializeField] float _speedLR = 0, _speedTD = 2.5f, _maxleft = 0, _maxRight = 0;
    [SerializeField] Button _buttton;
    private int _checkisMove = 0;
    float _posClaw = 0, _MoveX = 0;
    private bool _checkisClaw = false;
    public bool CheckIsClaw => _checkisClaw;
    Vector2 _lastPos = Vector2.zero;
    PlayerInput _PlayerInput;
    ClawArm _clawarm;
    GameObject _target;

    void Awake()
    {
        _target = GameManager.Instance.Lever;
        _clawarm = GetComponentInChildren<ClawArm>();
    }

    private void Start()
    {
        _PlayerInput = _target.GetComponent<PlayerInput>();

    }
    private void Update()
    {
        OnMoveClawLR();
        OnMoveClawTD();
    }
    public void setCloseClaw()
    {
        _checkisClaw = false;
    }

    public void setOnClaw()
    {
        _lastPos = this.transform.position;
        _checkisMove = 1;
        _checkisClaw = true;
        _buttton.interactable = false;
    }

    void OnMoveClawLR()
    {
        _posClaw = this.transform.position.x;
        _MoveX = _PlayerInput._moveMent.x == 0 ? 0 : _PlayerInput._moveMent.x > 0 ? 1 : -1;
        if ((_posClaw <= _maxleft && _MoveX < 0) || (_posClaw >= _maxRight && _MoveX > 0)) return;
        this.transform.position += new Vector3(_MoveX * _speedLR * Time.deltaTime, 0, 0);
    }
    void OnMoveClawTD()
    {
        if (_checkisMove == 1)
        {
            this.transform.position += Vector3.down * _speedTD * Time.deltaTime;
        }else if (_checkisMove == 2)
        {
            if(this.transform.position.y < _lastPos.y)
                this.transform.position += Vector3.up * _speedTD * Time.deltaTime;
            else
            {
                this.transform.position = _lastPos;
                _checkisMove = 0;
                _buttton.interactable = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("items") || other.CompareTag("Balls"))
        {
            StartCoroutine(CountDownClaw());
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("items") || other.CompareTag("Balls"))
        {
            if (this.transform.position.y == _lastPos.y)
            {
                other.gameObject.SetActive(false);
            };
        }
        
    }
    IEnumerator CountDownClaw()
    {
        if (_checkisClaw)
        {
            yield return new WaitForSeconds(0.5f);
            setCloseClaw();
            _checkisMove = 2;
        }
    }

}
