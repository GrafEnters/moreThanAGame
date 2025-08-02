using UnityEngine;

public interface IMovement {

    public void Init(Rigidbody rigidbody);
    
    public void OnUpdate(float speed);
}