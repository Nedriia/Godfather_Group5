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
            float roll = CrossPlatformInputManager.GetAxis("Horizontal");
            float pitch = CrossPlatformInputManager.GetAxis("Vertical");
            //Set back the value of roll level of aeroplaneController

            //if (roll == 0)
            //{
            //    m_Aeroplane.setM_lift(-0.05f);
            //    m_Aeroplane.setM_Roll(0.5f);
            //    //Change lift if no input has been detected
            //    if (CrossPlatformInputManager.GetAxis("Fire1") != 0 && CrossPlatformInputManager.GetAxis("Fire2") != 0)
            //    {
            //        //Debug.Log("Chicken's floating");
            //        m_Aeroplane.setM_lift(-0.005f);
            //    }
            //    else if (CrossPlatformInputManager.GetAxis("Fire1") > 0 || CrossPlatformInputManager.GetAxis("Fire1") < 0)
            //    {
            //        roll = CrossPlatformInputManager.GetAxis("Fire1") * -1;
            //        //Show all variables in inspector to fast change
            //        m_Aeroplane.setM_lift(-0.005f);
            //        m_Aeroplane.setM_Roll(0.2f);
            //    }
            //    else if (CrossPlatformInputManager.GetAxis("Fire2") > 0 && roll == 0)
            //    {
            //        roll = CrossPlatformInputManager.GetAxis("Fire2");
            //        //Show all variables in inspector to fast change
            //        m_Aeroplane.setM_lift(-0.005f);
            //        m_Aeroplane.setM_Roll(0.2f);
            //    }
            //}

            // auto throttle up, or down if braking.
            float throttle = 1;

            // Pass the input to the aeroplane
            m_Aeroplane.Move(roll, pitch, 0, throttle, false);
        }


        //private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
        //{
        //    // because mobile tilt is used for roll and pitch, we help out by
        //    // assuming that a centered level device means the user
        //    // wants to fly straight and level!

        //    // this means on mobile, the input represents the *desired* roll angle of the aeroplane,
        //    // and the roll input is calculated to achieve that.
        //    // whereas on non-mobile, the input directly controls the roll of the aeroplane.

        //    float intendedRollAngle = roll*maxRollAngle*Mathf.Deg2Rad;
        //    float intendedPitchAngle = pitch*maxPitchAngle*Mathf.Deg2Rad;
        //    roll = Mathf.Clamp((intendedRollAngle - m_Aeroplane.RollAngle), -1, 1);
        //    pitch = Mathf.Clamp((intendedPitchAngle - m_Aeroplane.PitchAngle), -1, 1);

        //    // similarly, the throttle axis input is considered to be the desired absolute value, not a relative change to current throttle.
        //    float intendedThrottle = throttle*0.5f + 0.5f;
        //    throttle = Mathf.Clamp(intendedThrottle - m_Aeroplane.Throttle, -1, 1);
        //}
    }
}
