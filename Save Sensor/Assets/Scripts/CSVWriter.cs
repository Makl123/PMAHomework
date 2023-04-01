using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class CSVWriter : MonoBehaviour
{
    private string filename;

    public void WriteCSV(string name, List<Vector3> list)
    {
        filename = Application.persistentDataPath + "/" + name + ".CSV";
        
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
