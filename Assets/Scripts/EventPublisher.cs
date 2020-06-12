using System;   // for EventHandler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventPublisher : MonoBehaviour {
    // EVENT PUBLISHER CLASS.  OTHER CLASSES / STRUCTS CAN SUBSCRIBE TO EVENTS THAT THIS CLASS PUBLISHES
    // NOTE THAT THE PUBLISHER NEEDS TO HANDLE SUBSCRIPTIONS / UNSUBSCRIPTIONS, SO THE SUBSCRIBER NEEDS TO HAVE A WAY TO ACCESS THE PUBLISHER AND EVENTS
    // ONE WAY TO DO THAT IS FOR THE SUBSCRIBER TO HAVE A REFERENCE TO THIS CLASS OR THE GAMEOBJECT HOLDING THIS CLASS
    // BUT AN EVEN BETTER WAY TO DO IT IS TO MAKE THE PUBLISHERS EVENT A STATIC EVENT THAT CAN BE ACCESSED FROM ANYWHERE AT ANYTIME.  USE THESE BY DEFAULT UNLESS IT'S IMPOSSIBLE
    // EXAMPLES BELOW SHOW MULTIPLE DIFFERENT WAYS OF HANDLING EVENTS IN UNITY

    public event EventHandler OnSpacePressed;   // C# event without custom event args
    public event EventHandler<OnReturnPressedEventArgs> OnReturnPressed;    // event with custom event args
    public class OnReturnPressedEventArgs : EventArgs { // customized event args for OnReturnPressed (needs to be a class to inherit from EventArgs)
        public int returnPressedCount;
    }
    private int returnCounter = 0;  // local variable to track how many times return pressed
    public delegate void TestEventDelegate(float f);    // using a delegate instead of an EventHandler for an event.  Delegates are basically function signatures (predefined parameters and return type)
    public event TestEventDelegate OnDelegateFloatEvent;    // creating an event for the delegate above


    private void Start() {
        OnSpacePressed += EventTestFunction;    // EventTestFunction (within this class below) is now subscribed to OnSpacePressed
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

        if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("***  D Pressed!  ***");
            OnDelegateFloatEvent?.Invoke(6.9f);
        }
    }

    private void EventTestFunction(object sender, EventArgs e) {
        Debug.Log("EventTestFunction triggered by " + sender);
    }

}
