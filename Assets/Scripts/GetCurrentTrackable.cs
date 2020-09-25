using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GetCurrentTrackable : MonoBehaviour, ITrackableEventHandler {
	protected TrackableBehaviour mTrackableBehaviour;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        return;
    }

    // Use this for initialization
    public string targetName(){
		StateManager sm = TrackerManager.Instance.GetStateManager ();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours ();

       // Iterate through the list of active trackables
       // Debug.Log ("List of trackables currently active (tracked): ");
        foreach (TrackableBehaviour tb in activeTrackables) {
            //Debug.Log("Trackable: " + tb.TrackableName);
            return tb.TrackableName;
        }
        // string n = mTrackableBehaviour.TrackableName;
        // Debug.Log(n);
        return "null";
	}
}
