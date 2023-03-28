using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;
    
        private InputAction touchPositionAction;
        private InputAction touchPressAction;

        private string _dataPath;
        private string _textFile;

      
        private Transform _rawGyroRotation;
        private float _tempSmoothing;

        //private float _frequency = Gyroscope.current.samplingFrequency;

        private TextMeshPro _frequencyText;
        


        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            touchPressAction = playerInput.actions["TouchPress"];
            touchPositionAction = playerInput.actions["TouchPosition"];
            //InputSystem.EnableDevice(Gyroscope.current);

            _dataPath = Application.persistentDataPath + "/Player_Data/";
            _textFile = _dataPath + "Save_Data.txt";
        }

    
        private void Update()
        {
            GetAccelerometerValue();
        }

        Vector3 GetAccelerometerValue()
        {
            Input.gyro.enabled = true;
            //Gyroscope.current.samplingFrequency = 16;
            Vector3 acc = Vector3.zero;
            float period = 0.0f;

            foreach (AccelerationEvent evnt in Input.accelerationEvents)
            {
                acc += evnt.acceleration * evnt.deltaTime;
                period += evnt.deltaTime;
            }

            if (period > 0)
            {
                acc *= 1.0f / period;
            }

            return acc;
        }

        private void OnEnable()
        {
            touchPressAction.performed += TouchPressed;
        }
    
        private void OnDisable()
        {
            touchPressAction.performed -= TouchPressed;
        }
    
        private void TouchPressed(InputAction.CallbackContext context)
        {
            float value = context.ReadValue<float>();
            Debug.Log(value);
            context.ReadValueAsObject();
            Debug.Log(Input.acceleration.x);
            Start();

        }

        private void NewDirectory()
        {
            if (Directory.Exists(_dataPath))
            {
                Debug.Log("Directory already exists...");
                return;
            }
            
            Directory.CreateDirectory(_dataPath);
            Debug.Log("New directory created!");
        }

        public void NewTextFile()
        {
            if (File.Exists(_textFile))
            {
                Debug.Log("File already exists...");
                return;
            }

            File.WriteAllText(_textFile, "<SAVE DATA>");
            Debug.Log("New file created!");

        }

        public void ReadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Debug.Log("File doesn't exist...");
                return;
            }
            
            Debug.Log(File.ReadAllText(filename));

           // var writer = new BinaryWriter();
           
        }

        private IEnumerator Start()
        {
            Input.gyro.enabled = true;
            Application.targetFrameRate = 60;

            yield return new WaitForSeconds(2);

            print(GetAccelerometerValue());
            
            //File.WriteAllText(_textFile,$"Value: {0}",GetAccelerometerValue());
            
            
        }

        

        
        
}
