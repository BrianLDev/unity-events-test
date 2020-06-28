using System;   // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase {

    public static Action<string> OnShout;

    private new void Start() {
        base.Start();   
        GameManagerTest.OnRestartGame += Restart;
    }

    private void Update() {
        Move();
    }

    public void Move() {
        if (alive) {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                transform.Translate(transform.right);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                transform.Translate(-transform.right);
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                transform.Translate(transform.forward);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                transform.Translate(-transform.forward);
        }
    }

    public new void Restart() {
        base.Restart();
        // add any restart things that are custom to the player here
    }

}
