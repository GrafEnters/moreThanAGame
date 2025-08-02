using System;
using UnityEngine;

public class AndroidWasdView : MonoBehaviour {
    private Rigidbody _rb;
    private float _speed;

    private bool _isUp, _isDown, _isLeft, _isRight;

    public void Init(Rigidbody rb) {
        _rb = rb;
    }

    public void UpdateSpeed(float speed) {
        _speed = speed;
    }

    public void Up() {
        _isUp = true;
    }

    public void UpRelease() {
        _isUp = false;
    }

    public void Right() {
        _isRight = true;
    }

    public void RightRelease() {
        _isRight = false;
    }

    public void Down() {
        _isDown = true;
    }

    public void DownRelease() {
        _isDown = false;
    }

    public void Left() {
        _isLeft = true;
    }

    public void LeftRelease() {
        _isLeft = false;
    }

    private void FixedUpdate() {
        if (_isUp) {
            _rb.MovePosition(_rb.position + Vector3.forward * _speed);
        }

        if (_isLeft) {
            _rb.MovePosition(_rb.position + Vector3.left * _speed);
        }

        if (_isDown) {
            _rb.MovePosition(_rb.position + Vector3.back * _speed);
        }

        if (_isRight) {
            _rb.MovePosition(_rb.position + Vector3.right * _speed);
        }
    }
}