using System;
using System.Collections;
using UnityEngine;

public class Homlin : MonoBehaviour {
    public Transform Transform;

    public float Speed;
    public int Strength = 5;

    public GameManager GameManager;

    public Rigidbody Rigidbody;

    public Transform ItemsContainer;

    public float ItemHeight;
    private bool IsSelling;
    private int _currentItemsCount;

    [SerializeField]
    private float _takeAnimationTime = 0.5f;

    [SerializeField]
    private AnimationCurve _takeAnimationCurve;

    [SerializeField]
    private GameObject _hat;

    private IMovement _movement;

    private void Start() {
        _hat.SetActive(false);


#if UNITY_ANDROID 
        _movement = new AndroidMovement();
#else
        _movement = new WindowsMovement();
#endif
        
        
        _movement.Init(Rigidbody);
    }

    void FixedUpdate() {
        _movement.OnUpdate(Speed *100* Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        GameManager.CollectItem(other.collider.attachedRigidbody);
    }

    public void TakeItem(Rigidbody item) {
        if (item.transform.parent == ItemsContainer) {
            return;
        }

        if (_currentItemsCount >= Strength) {
            return;
        }

        item.transform.parent = ItemsContainer;
        var finalShift = Vector3.up * _currentItemsCount * ItemHeight;
        _currentItemsCount++;
        StartCoroutine(TakeItemWithAnimation(item.transform, ItemsContainer, finalShift));

        item.detectCollisions = false;
        item.isKinematic = true;
    }

    private IEnumerator TakeItemWithAnimation(Transform item, Transform parent, Vector3 shift) {
        var startingPos = item.transform.position;

        float curTime = 0;

        while (curTime < _takeAnimationTime) {
            var percent = curTime / _takeAnimationTime;

            Vector3 nextPos = Vector3.LerpUnclamped(startingPos, parent.position + shift, percent);
            float nextY = Mathf.LerpUnclamped(startingPos.y, parent.position.y + shift.y, _takeAnimationCurve.Evaluate(percent));
            nextPos.y = nextY;

            item.transform.position = nextPos;

            yield return new WaitForEndOfFrame();
            curTime += Time.deltaTime;
        }

        item.transform.position = parent.position + shift;
    }

    public void SellItems() {
        if (IsSelling) {
            return;
        }

        IsSelling = true;
        GameManager.SellItems(ItemsContainer);
        foreach (Transform child in ItemsContainer) {
            Destroy(child.gameObject);
        }

        _currentItemsCount = 0;
    }

    private void LateUpdate() {
        IsSelling = false;
    }

    public void ActivateHat() {
        _hat.SetActive(true);
    }
}