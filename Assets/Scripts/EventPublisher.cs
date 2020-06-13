using System;               // for EventHandler, Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;   // for UnityEvent

public class EventPublisher : MonoBehaviour {
    // EVENT PUBLISHER CLASS.  OTHER CLASSES / STRUCTS CAN SUBSCRIBE TO EVENTS THAT THIS CLASS PUBLISHES
    // NOTE THAT THE PUBLISHER NEEDS TO HANDLE SUBSCRIPTIONS / UNSUBSCRIPTIONS, SO THE SUBSCRIBER NEEDS TO HAVE A WAY TO ACCESS THE PUBLISHER AND EVENTS
    // ONE WAY TO DO THAT IS FOR THE SUBSCRIBER TO HAVE A REFERENCE TO THIS CLASS OR THE GAMEOBJECT HOLDING THIS CLASS
    // BUT AN EVEN BETTER WAY TO DO IT IS TO MAKE THE PUBLISHERS EVENT A STATIC EVENT THAT CAN BE ACCESSED FROM ANYWHERE AT ANYTIME.  USE THESE BY DEFAULT UNLESS IT'S IMPOSSIBLE
    // EXAMPLES BELOW SHOW MULTIPLE DIFFERENT WAYS OF HANDLING EVENTS IN UNITY

    public event EventHandler OnEPressed;   // C# event without custom event args
    public event EventHandler<OnReturnPressedEventArgs> OnReturnPressed;    // event with custom event args
    public class OnReturnPressedEventArgs : EventArgs { // customized event args for OnReturnPressed (needs to be a class to inherit from EventArgs)
        public int returnPressedCount;
    }
    private int returnCounter = 0;  // local variable to track how many times return pressed
    public delegate void TestEventDelegate(float f);    // using a delegate instead of an EventHandler for an event.  Delegates are basically function signatures (predefined parameters and return type)
    public event TestEventDelegate OnDelegateFloatEvent;    // creating an event for the delegate above
    public event Action OnActionEventSimple;  // creating an event using Action instead of EventHandler.  Actions combine creating a delegate and event and can have customized parameters
    public event Action<bool, int, OnReturnPressedEventArgs> OnActionEventCustom;   // This Action event takes 3 custom parameters including the class made above
    public UnityEvent OnUnityEvent; // Unity event - customizable within unity editor (note that you don't need to type event before UnityEvent)


    private void Start() {
        OnEPressed += EventTestFunction;    // EventTestFunction (within this class below) is now subscribed to OnEPressed
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("***  E pressed!  ***");
            // if(OnEPressed != null) { OnEPressed(this, EventArgs.Empty); }
            // use the ? null conditional operator added in C# 6 to trim the above line down
            OnEPressed?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("***  Return Pressed!  ***");
            returnCounter++;
            OnReturnPressed?.Invoke(this, new OnReturnPressedEventArgs { returnPressedCount = returnCounter });
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("***  D Pressed!  ***");
            OnDelegateFloatEvent?.Invoke(6.9f);
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("***  A Pressed!  ***");
            OnActionEventSimple?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.C)) {
            Debug.Log("***  C Pressed!  ***");
            returnCounter++;
            OnActionEventCustom?.Invoke(true, 13, new OnReturnPressedEventArgs { returnPressedCount = returnCounter });
        }
        else if (Input.GetKeyDown(KeyCode.U)) {
            Debug.Log("***  U Pressed!  ***");
            OnUnityEvent?.Invoke();
        }
    }

    private void EventTestFunction(object sender, EventArgs e) {
        Debug.Log("EventTestFunction triggered by " + sender);
    }


}
