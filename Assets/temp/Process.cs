using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
    public class Process : MonoBehaviour
    {

        public PostProcessingBehaviour test;

        //public PostProcessingBehaviour postProcess;
        private ChromaticAberrationModel.Settings Profilsetting;
        public AeroplaneController chicken;
        private float chroma;

        private void Start()
        {
            test = Camera.main.GetComponent<PostProcessingBehaviour>();
            chicken = GetComponent<AeroplaneController>();
            //postProcess = Camera.main.GetComponent<PostProcessingBehaviour>();
        }

        // Update is called once per frame
        void Update()
        {
            if(chicken.EnginePower > 1)
            {
                var testtest = test.profile.chromaticAberration.settings;
                chroma += 1.5f * Time.deltaTime;
                chroma = Mathf.Clamp(chroma, 0,1.5f);
                testtest.intensity = chroma;
                test.profile.chromaticAberration.settings = testtest;
            }
            else
            {
                var testtest = test.profile.chromaticAberration.settings;
                chroma -= 3f * Time.deltaTime;
                chroma = Mathf.Clamp(chroma, 0, 1.5f);
                testtest.intensity = chroma;
                test.profile.chromaticAberration.settings = testtest;
            }
        }
    }
}
