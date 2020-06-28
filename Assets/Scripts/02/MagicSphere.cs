using System;   // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : MonoBehaviour {

    public enum SphereType { Healing, Damaging };
    [SerializeField] SphereType sphereType;
    private float countdown = 1.0f;


    private void OnTriggerEnter(Collider other) {
        // subscribe to sphere heal / damage if game object that enters is a player or enemy
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            if(sphereType == SphereType.Healing)
                GameManagerTest.OnSphereHeal += player.Heal;
            else
                GameManagerTest.OnSphereDamage += player.TakeDamage;
        }
        else if (other.gameObject.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (sphereType == SphereType.Healing)
                GameManagerTest.OnSphereHeal += enemy.Heal;
            else
                GameManagerTest.OnSphereDamage += enemy.TakeDamage;
        }
    }

    private void OnTriggerExit(Collider other) {
        // unsubscribe to sphere heal / damage if game object that enters is a player or enemy
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            if(sphereType == SphereType.Healing)
                GameManagerTest.OnSphereHeal -= player.Heal;
            else
                GameManagerTest.OnSphereDamage -= player.TakeDamage;
        }
        else if (other.gameObject.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if(sphereType == SphereType.Healing)
                GameManagerTest.OnSphereHeal -= enemy.Heal;
            else
                GameManagerTest.OnSphereDamage -= enemy.TakeDamage;
        }
    }
}