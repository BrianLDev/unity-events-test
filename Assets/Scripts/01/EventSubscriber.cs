using System;   // for EventHandler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour {
    // SUBSCRIBER CLASS

    EventPublisher publisher;  // need a reference to the publisher class to subscribe to events.  If the publisher class is static, this is not needed and can reference the class directly
    
        
    private void Start() {
        publisher = GetComponent<EventPublisher>();
        publisher.OnEPressed += OtherClassFunction;    // OtherClassFunction is now subscribed to OnEPressed
        publisher.OnEPressed += UnsubscribeFunction;   // UnsubscribeTest is now subscribed to OnEPressed
        publisher.OnReturnPressed += OtherClassFunction;    // OtherClassFunction is now subscribed to OnEnterPressed
        publisher.OnReturnPressed += UnsubscribeFunction;   // UnsubscribeTest is now subscribed to OnEnterPressed
        publisher.OnDelegateFloatEvent += DelegateFloatFunction;  // DelegateFloatSubscriber is now subscribed to OnDelegateFloatEvent
        publisher.OnActionEventSimple += ActionFunction;
        publisher.OnActionEventCustom += ActionFunction;
    }

    public void OtherClassFunction(object sender, EventArgs e) {
        Debug.Log("OtherClassFunction triggered by " + sender);
    }
    public void OtherClassFunction(object sender, EventPublisher.OnReturnPressedEventArgs e) {
        // alternate version that takes the custom event args for OnReturnPressed
        Debug.Log("OtherClassFunction triggered by " + sender + ".  Return count = " + e.returnPressedCount);
    }
    public void UnsubscribeFunction(object sender, EventArgs e) {
        Debug.Log("UnsubscribeFunction triggered by " + sender +
            ".  Now unsubscribing this func from OnSpace and should not come up again.");
        publisher.OnEPressed -= UnsubscribeFunction;
    }
    public void UnsubscribeFunction(object sender, EventPublisher.OnReturnPressedEventArgs e) {
        // alternate version that takes the custom event args for OnReturnPressed
        Debug.Log("UnsubscribeFunction triggered by " + sender +
            ".  Now unsubscribing this func from OnReturn and should not come up again.");
        publisher.OnReturnPressed -= UnsubscribeFunction;
    }
    public void DelegateFloatFunction(float f) {
        Debug.Log("DelegateFloatSubscriber function triggered. Float value = " + f);
    }
    public void ActionFunction() {
        Debug.Log("ActionFunction triggered.");
    }
    public void ActionFunction(bool b, int i, EventPublisher.OnReturnPressedEventArgs e) {
        Debug.Log("ActionFunction triggered. Bool = " + b + ", Int = " + i + ", Return count = " + e.returnPressedCount);
    }
}
