using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroScopeReader : MonoBehaviour
{

    public GyroScopeReader(float x, float z)
    {
        xThreshold = x;
        zThreshold = z;

    }

    private float xThreshold;
    private float zThreshold;

    public bool IsFlat()
    {
        if (AttitudeSensor.current.attitude.ReadValue().x <= xThreshold &&)
        {
            
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
