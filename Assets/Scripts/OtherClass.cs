using System;   // for EventHandler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherClass : MonoBehaviour {
    // SUBSCRIBER CLASS

    EventsPublisher eventsPublisher;
        
    private void Start() {
        eventsPublisher = GetComponent<EventsPublisher>();
        eventsPublisher.OnSpacePressed += OtherClassFunction;    // OtherClassFunction is now subscribed to OnSpacePressed
        eventsPublisher.OnSpacePressed += UnsubscribeFunction;   // UnsubscribeTest is now subscribed to OnSpacePressed
        eventsPublisher.OnReturnPressed += OtherClassFunction;    // OtherClassFunction is now subscribed to OnEnterPressed
        eventsPublisher.OnReturnPressed += UnsubscribeFunction;   // UnsubscribeTest is now subscribed to OnEnterPressed
    }

    public void OtherClassFunction(object sender, EventArgs e) {
        Debug.Log("OtherClassFunction triggered by " + sender);
    }

    public void OtherClassFunction(object sender, EventsPublisher.OnReturnPressedEventArgs e) {
        // alternate version that takes the custom event args for OnReturnPressed
        Debug.Log("OtherClassFunction triggered by " + sender + ".  Return count = " + e.returnPressedCount);
    }

    public void UnsubscribeFunction(object sender, EventArgs e) {
        Debug.Log("UnsubscribeFunction triggered by " + sender +
            ".  Now unsubscribing this func from OnSpace and should not come up again.");
        eventsPublisher.OnSpacePressed -= UnsubscribeFunction;
    }
    public void UnsubscribeFunction(object sender, EventsPublisher.OnReturnPressedEventArgs e) {
        // alternate version that takes the custom event args for OnReturnPressed
        Debug.Log("UnsubscribeFunction triggered by " + sender +
            ".  Now unsubscribing this func from OnReturn and should not come up again.");
        eventsPublisher.OnReturnPressed -= UnsubscribeFunction;
    }
}
