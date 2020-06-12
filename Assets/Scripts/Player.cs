using System;   // for EventHandler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] EventPublisher eventPublisher;

    public int health = 100;
    public int energy = 100;

    private void Start() {
        
    }

}
