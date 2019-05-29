using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Signal : ScriptableObject {

    public List<SignalListener> listeners = new List<SignalListener>();

    //loop through all signals
    public void Raise() //Raise the alarm to say signal has been raised by a listener
    {
        for(int i = listeners.Count -1; i >= 0; i --)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener) //Add listener to signal
    {
        listeners.Add(listener);
    }

    public void DeRegisterListner(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
