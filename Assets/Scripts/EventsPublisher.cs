using System;   // for EventHandler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsPublisher : MonoBehaviour {
    // EVENT PUBLISHER CLASS.  OTHER CLASSES / STRUCTS CAN SUBSCRIBE
    public event EventHandler OnSpacePressed;                           // event without custom event args
    public event EventHandler<OnReturnPressedEventArgs> OnReturnPressed;  // event with custom event args
    public class OnReturnPressedEventArgs : EventArgs {                  // customized event args
        public int returnPressedCount;
    }
    private int returnCounter = 0;

    private void Start() {
        OnSpacePressed += EventTestFunction;    // EventTestFunction is now subscribed to OnSpacePressed
        OnReturnPressed += EventTestFunction;    // EventTestFunction is now subscribed to OnReturnPressed
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("***  Space pressed!  ***");
            // if(OnSpacePressed != null) { OnSpacePressed(this, EventArgs.Empty); }
            // use the ? null conditional operator added in C# 6 to trim the above line down
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("***  Return Pressed!  ***");
            returnCounter++;
            OnReturnPressed?.Invoke(this, new OnReturnPressedEventArgs { returnPressedCount = returnCounter });
        }
    }

    private void EventTestFunction(object sender, EventArgs e) {
        Debug.Log("EventTestFunction triggered by " + sender);
    }

    private void EventTestFunction(object sender, OnReturnPressedEventArgs e) {
        // alternate version that takes the custom event args for OnReturnPressed
        Debug.Log("EventTestFunction triggered by " + sender + ".  Return count = " + e.returnPressedCount);
    }
}
