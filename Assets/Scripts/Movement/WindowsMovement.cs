using UnityEngine;

public class WindowsMovement : IMovement {
    private Rigidbody _rb;

    public void Init(Rigidbody rigidbody) {
        _rb = rigidbody;
    }

    public void OnUpdate(float speed) {
        if (Input.GetKey(KeyCode.W)) {
            _rb.MovePosition(_rb.position + Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            _rb.MovePosition(_rb.position + Vector3.left * speed);
        }

        if (Input.GetKey(KeyCode.S)) {
            _rb.MovePosition(_rb.position + Vector3.back * speed);
        }

        if (Input.GetKey(KeyCode.D)) {
            _rb.MovePosition(_rb.position + Vector3.right * speed);
        }
    }
}