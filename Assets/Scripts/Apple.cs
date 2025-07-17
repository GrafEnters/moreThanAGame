using System;
using UnityEngine;

public class Apple : MonoBehaviour {
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