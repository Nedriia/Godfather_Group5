﻿using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float distanceAttenteJoueur = 100;
        public float speedWait = 2.5f;
        float lastSpeed;
        float distanceTravelled;
        float diff;
        bool estRalenti = false;
        GameObject joueur;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
                joueur = GameObject.FindWithTag("Player");
                lastSpeed = speed;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                
                diff = Vector3.Distance(joueur.transform.position, transform.position);

                //Debug.Log("Distance : " + diff);

                if ( diff > distanceAttenteJoueur && !estRalenti)
                {
                    estRalenti = true;
                    //speed = Mathf.Lerp(speed,speedWait,Time.deltaTime * 2);
                    speed = speedWait;
                }

                if (diff < distanceAttenteJoueur)
                {
                    estRalenti = false;
                    speed = lastSpeed;
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            /*if(tag == player)
            {
                scenemanagement.load();

            }*/
        }
    }
}