using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class InputKey
{
    public KeyCode keyCode;

    public bool down;
    public bool held;
    public bool up;

    public bool enable = true;

    public InputKey(KeyCode keyCode)
    {
        this.keyCode = keyCode;
        down = false;
        held = false;
        up = false;
    }

    public void Get()
    {
        if (enable)
        {
            down = Input.GetKeyDown(keyCode);
            held = Input.GetKey(keyCode);
            up = Input.GetKeyUp(keyCode);
        }
    }
}
