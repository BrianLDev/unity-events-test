using System;   // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase {


    public static Action<int> OnPlayerDamage;
    public static Action<int> OnPlayerHeal;
    public static Action<string> OnShout;

    private new void Start() {
        base.Start();   
        OnPlayerDamage += TakeDamage;
        OnPlayerHeal += Heal;
        GameManagerTest.OnRestartGame += Restart;
    }

    private void Update() {

        Move();
        
        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus)) {
            if (alive && health < 100) {
                OnPlayerHeal?.Invoke(10);
            }
        }
        if (Input.GetKeyDown(KeyCode.Minus)) {
            if (alive && health > 0) {
                OnPlayerDamage?.Invoke(10);
            }
        }

    }

    public void Move() {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.Translate(transform.right);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Translate(-transform.right);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.Translate(transform.forward);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.Translate(-transform.forward);
    }

    public new void Restart() {
        base.Restart();
        // add any restart things that are custom to the player here
    }

}
