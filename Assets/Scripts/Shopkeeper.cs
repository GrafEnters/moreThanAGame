using System;
using UnityEngine;

public class Shopkeeper : MonoBehaviour {
    
    
    //Проверять, не коснулся ли его Хомлин

    private void OnCollisionEnter(Collision other) {
        var body = other.collider.attachedRigidbody;
        if (body == null) {
            return;
        }
        Homlin homlin = body.GetComponent<Homlin>();
        if (homlin == null) {
            return;
        }
        
        homlin.SellFruits();
    }

    
}