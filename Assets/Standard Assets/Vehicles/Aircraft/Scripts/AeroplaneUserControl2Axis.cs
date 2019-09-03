using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
    [RequireComponent(typeof (AeroplaneController))]
    public class AeroplaneUserControl2Axis : MonoBehaviour
    {
        // these max angles are only used on mobile, due to the way pitch and roll input are handled
        public float maxRollAngle = 80;
        public float maxPitchAngle = 80;

        [Header("Input value")]
        public float leftTrigger;
        public float rightTrigger;
  
        [Header("Wings value")]
        public float liftFullWings;
        public float lift1_wings;
        public float liftWithout_wings;

        // reference to the aeroplane that we're controlling
        private AeroplaneController m_Aeroplane;

        private void Awake()
        {
            // Set up the reference to the aeroplane controller.
            m_Aeroplane = GetComponent<AeroplaneController>();
        }

        private void FixedUpdate()
        {
            // Read input for the pitch, yaw, roll and throttle of the aeroplane.
            float pitch = CrossPlatformInputManager.GetAxis("Vertical");
            float roll = 0;
            //Set back the value of roll level of aeroplaneController

            leftTrigger = Input.GetAxis("LeftTrigger");
            rightTrigger = Input.GetAxis("RightTrigger");

            leftTrigger = Mathf.Clamp(leftTrigger, 0, 1);
            rightTrigger = Mathf.Clamp(rightTrigger, 0, 1);

            if (leftTrigger == 0 && rightTrigger == 0)
            {
                //Debug.Log("Chicken's floating");
                //Animation des deux ailes tendues
            }
            else if (leftTrigger != 0)
            {
                roll = -1;
                //fermeture de l'aile à gauche
            }
            else if(rightTrigger != 0)
            {
                roll = 1;
                //fermeture de l'aile à droite
            }
            if(leftTrigger != 0 && rightTrigger !=0)
            {
                //Chicken's falling
                //Fermeture des deux ailes
                roll = 0;
            }

            float throttle = 1;

            // Pass the input to the aeroplane
            m_Aeroplane.Move(roll, pitch, 0, throttle, false);
        }
    }
}
