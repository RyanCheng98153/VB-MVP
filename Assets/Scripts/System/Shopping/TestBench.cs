using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBench : MonoBehaviour
{
    public KeyCode keyCode;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode)){
            Debug.Log(this.name);
        }
    }
}
