using System;   // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {
    public int health = 100;
    public int energy = 100;
    
    protected bool alive = true;
    protected MeshRenderer rend;

    protected void Start() {
        rend = GetComponent<MeshRenderer>();
        GameManagerTest.OnRestartGame += Restart;
    }

    public void ChangeColor() {
        if(alive) {
            Color c = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
            rend.material.color = c;
        }
    }
    public void ChangeColor(Color color) {
        if (alive) {
            rend.material.color = color;
        }
    }

    public void TakeDamage(int damage) {
        if (alive && health > 0) {
            ChangeColor(Color.red);
            health = Mathf.Clamp(health - damage, 0, 100);
            Debug.Log(this.name + " damaged for " + damage + ". Health now at " + health);
            if (health <= 0) 
                Die();
        }
    }

    public void Heal(int healPts) {
        if (alive && health < 100) {
            ChangeColor(Color.green);
            health = Mathf.Clamp(health + healPts, 0, 100);
            Debug.Log(this.name + " healed for " + healPts + ". Health now at " + health);
        }
    }

    public void Die() {
        Debug.Log("===== " + this.name + " IS DEAD ====");
        alive = false;
        ChangeColor(Color.black);
        transform.Rotate(69, 13, 24);
    }

    public void Restart() {
        health = 100;
        alive = true;
        rend.material.color = Color.white;
        transform.rotation = Quaternion.identity;
    }
}
