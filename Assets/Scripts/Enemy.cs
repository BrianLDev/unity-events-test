using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase {

    private new void Start() {
        base.Start();   
        Player.OnPlayerDamage += VampireHeal;   // Enemy has special power that steals health from player when player is damaged. Subscribed to player event here
        Player.OnPlayerHeal += VampireDamage;   // Same but it takes damage when player heals self
    }

    private void Update() {

    }

    public void VampireHeal(int healPts) {
        if (alive && health < 100) {
            healPts /= 3;
            Debug.Log("~~ Vampire absorbs " + healPts + " health");
            Heal(healPts);
        }
    }

    public void VampireDamage(int damage) {
        if (alive && health > 0) {
            damage /= 3;
            Debug.Log("~~ Vampire absorbs " + damage + " damage");
            TakeDamage(damage);
        }
    }

}
