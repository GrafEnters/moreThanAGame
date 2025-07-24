using System;
using UnityEngine;

public class UpgradeZone : MonoBehaviour {

    [SerializeField]
    private Animation _buttonsAnimation;

    [SerializeField]
    private AnimationClip _showClip, _hideClip;

    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) {
            return;
        }

        _buttonsAnimation.Play(_showClip.name);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.gameObject.CompareTag("Player")) {
            return;
        }
        _buttonsAnimation.Play(_hideClip.name);
    }
}
