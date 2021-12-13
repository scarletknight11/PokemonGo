using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAlive : MonoBehaviour {

    private void Start()
    {
        //keeps gameobject alive when we switch scenes
        DontDestroyOnLoad(gameObject);
        //only destroys the script itself
        Destroy(this);
    }
     
}
