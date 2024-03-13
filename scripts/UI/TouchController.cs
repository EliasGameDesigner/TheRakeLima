using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public FirstPersonLook _CameraLook;
    void Start()
    {
        
    }

    
    void Update()
    {
        _CameraLook.Toque = _FixedTouchField.TouchDist;
        
    }
}
