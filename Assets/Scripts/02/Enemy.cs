using System;   // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase {

    bool isVampire;

    private new void Start() {
        base.Start();   
        // Player.OnDamage += VampireHeal;   // Enemy has special power that steals health from player when player is damaged. Subscribed to player event here
        // Player.OnHeal += VampireDamage;   // Same but it takes damage when player heals self
    }

    private void Update() {

    }

    private void FixedUpdate() {
        Move();
    }

    public void Move() {
        if (alive) {
            transform.Translate(transform.forward * 0.03f);
            if(UnityEngine.Random.Range(1,100) == 1) {
                transform.Rotate(0,15,0);
            }
            else if(UnityEngine.Random.Range(1,100) <= 3) {
                transform.Rotate(0,-15,0);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        GetComponent<Rigidbody>().AddForce(other.transform.forward * 200);
        if (other.rigidbody)
            other.rigidbody.AddForce(-other.transform.forward * 200);

        if(other.gameObject.tag == "Player" && !isVampire) {
            Player p = other.gameObject.GetComponent<Player>();
            p.TakeDamage(25);
            isVampire = true;
        }
        else if(other.gameObject.tag == "Enemy") {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamage(10);
        }
    }

    // VAMPIRE HEAL/DAMAGE - NOT USING RIGHT NOW.  MAY ADD BACK IN AGAIN LATER
    // public void VampireHeal(int healPts) {
    //     if (alive && health < 100) {
    //         healPts /= 3;
    //         Debug.Log("~~ Vampire absorbs " + healPts + " health");
    //         Heal(healPts);
    //     }
    // }
    // public void VampireDamage(int damage) {
    //     if (alive && health > 0) {
    //         damage /= 3;
    //         Debug.Log("~~ Vampire absorbs " + damage + " damage");
    //         TakeDamage(damage);
    //     }
    // }

    public new void Restart() {
        base.Restart();
    }

}
