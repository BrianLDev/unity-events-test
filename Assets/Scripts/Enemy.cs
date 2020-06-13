using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase {

    private new void Start() {
        base.Start();   
        Player.OnPlayerDamage += VampireHeal;
        Player.OnPlayerHeal += VampireDamage;
    }

    public void VampireHeal(int healPts) {
        if (alive && health < 100) {
            healPts /= 3;
            health = Mathf.Clamp(health + healPts, 0, 100);
            Debug.Log("Vampire absorbs health for " + healPts + ".  Health now at " + health);
        }
    }

    public void VampireDamage(int damage) {
        if (alive && health > 0) {
            damage /= 3;
            health = Mathf.Clamp(health - damage, 0, 100);
            Debug.Log("Vampire absorbs damage for " + damage + ".  Health now at " + health);
        }
    }

}
