using System;   // for EventHandler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour {
    // SUBSCRIBER CLASS

    EventPublisher publisher;  // need a reference to the publisher class to subscribe to events.  If they are static, this is not needed
    
        
    private void Start() {
        publisher = GetComponent<EventPublisher>();
        publisher.OnSpacePressed += OtherClassFunction;    // OtherClassFunction is now subscribed to OnSpacePressed
        publisher.OnSpacePressed += UnsubscribeFunction;   // UnsubscribeTest is now subscribed to OnSpacePressed
        publisher.OnReturnPressed += OtherClassFunction;    // OtherClassFunction is now subscribed to OnEnterPressed
        publisher.OnReturnPressed += UnsubscribeFunction;   // UnsubscribeTest is now subscribed to OnEnterPressed
        publisher.OnDelegateFloatEvent += DelegateFloatSubscriber;  // DelegateFloatSubscriber is now subscribed to OnDelegateFloatEvent
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
        publisher.OnSpacePressed -= UnsubscribeFunction;
    }
    public void UnsubscribeFunction(object sender, EventPublisher.OnReturnPressedEventArgs e) {
        // alternate version that takes the custom event args for OnReturnPressed
        Debug.Log("UnsubscribeFunction triggered by " + sender +
            ".  Now unsubscribing this func from OnReturn and should not come up again.");
        publisher.OnReturnPressed -= UnsubscribeFunction;
    }

    public void DelegateFloatSubscriber(float f) {
        Debug.Log("DelegateFloatSubscriber function triggered. Float value = " + f);
    }
}
