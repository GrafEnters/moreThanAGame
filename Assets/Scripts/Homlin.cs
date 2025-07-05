using System;
using UnityEngine;

public class Homlin : MonoBehaviour {
    public Transform Transform;

    public float Speed;

    public GameManager GameManager;

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            Transform.position += Vector3.forward * Speed;
        }

        if (Input.GetKey(KeyCode.A)) {
            Transform.position += Vector3.left * Speed;
        }

        if (Input.GetKey(KeyCode.S)) {
            Transform.position += Vector3.back * Speed;
        }

        if (Input.GetKey(KeyCode.D)) {
            Transform.position += Vector3.right * Speed;
        }
    }

    private void OnCollisionEnter(Collision other) {
        GameManager.CollectCrop(other.collider.attachedRigidbody);
    }
}