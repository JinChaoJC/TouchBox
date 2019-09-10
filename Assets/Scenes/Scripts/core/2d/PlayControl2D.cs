using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayControl2D : MonoBehaviour
{

    public EventSystem EventSystem;
    
    private void Update()
    {
        var ss = EventSystem.current;

        var s1 = EventSystem.current.currentSelectedGameObject;
        if (s1 != null)
            Debug.Log("s1 : " + s1.name);
        var s2 = EventSystem.current.firstSelectedGameObject;
        if (s2 != null)
            Debug.Log("s2 : " + s2.name);

    }
}
