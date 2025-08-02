using UnityEngine;

public class AndroidMovement : IMovement {
    private AndroidWasdView _view;

    public void Init(Rigidbody rigidbody) {
        AndroidWasdView prefab = Resources.Load<AndroidWasdView>("AndroidWASDView");

        Canvas canvas = Object.FindFirstObjectByType<Canvas>();

        _view = Object.Instantiate(prefab, canvas.transform);
        _view.Init(rigidbody);
    }

    public void OnUpdate(float speed) {
        _view.UpdateSpeed(speed);
    }
}