using System;               // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour {

    public static event Action OnRestartGame;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("=-=-=-=- RESTARTING -=-=-=-=");
            OnRestartGame?.Invoke();
        }
    } 

}
