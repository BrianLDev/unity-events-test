using System;   // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : MonoBehaviour {

    public static event Action<int> OnSphereHeal;
    public static event Action<int> OnSphereDamage;

    private void Update() {        

        if (Input.GetKeyDown(KeyCode.RightBracket)) {
            OnSphereHeal?.Invoke(2);
        }
        else if (Input.GetKeyDown(KeyCode.LeftBracket)) {
            OnSphereDamage?.Invoke(2);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // subscribe to sphere heal / damage if game object that enters is a player or enemy
        Debug.Log(other.gameObject.name + " entered sphere");
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            OnSphereHeal += player.Heal;
            OnSphereDamage += player.TakeDamage;
        }
        else if (other.gameObject.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            OnSphereHeal += enemy.Heal;
            OnSphereDamage += enemy.TakeDamage;
        }
    }

    private void OnTriggerExit(Collider other) {
        // unsubscribe to sphere heal / damage if game object that enters is a player or enemy
        Debug.Log(other.gameObject.name + " exited sphere");
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            OnSphereHeal -= player.Heal;
            OnSphereDamage -= player.TakeDamage;
        }
        else if (other.gameObject.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            OnSphereHeal -= enemy.Heal;
            OnSphereDamage -= enemy.TakeDamage;
        }
    }
}