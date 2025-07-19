using System;
using UnityEngine;

public class Autodestroy : MonoBehaviour {
    public Rigidbody RigidBody;

    private void Start() {
        Invoke(nameof(TryDestroy), 5);
    }

    private void TryDestroy() {
        if (RigidBody.detectCollisions) {
            Destroy(gameObject);
        }
    }
}