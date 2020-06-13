using System;               // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour {

    public static event Action<int> OnSphereHeal;
    public static event Action<int> OnSphereDamage;
    public static event Action<int> OnHealAll;
    public static event Action<int> OnDamageAll;
    public static event Action OnRestartGame;

    private float countdown = 0.2f;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("=-=-=-=- RESTARTING -=-=-=-=");
            OnRestartGame?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus)) {
            OnHealAll?.Invoke(5);
        }
        if (Input.GetKeyDown(KeyCode.Minus)) {
            OnDamageAll?.Invoke(5);
        }
    } 

    private void FixedUpdate() {   

        countdown -= Time.fixedDeltaTime;
        if (countdown <= 0) {
            OnSphereHeal?.Invoke(1);
            OnSphereDamage?.Invoke(1);

            countdown = 0.2f;
        }
    }

}
