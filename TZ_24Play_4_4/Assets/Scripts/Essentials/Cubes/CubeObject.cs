using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class CubeObject : MonoBehaviour
    {
        public bool checkForCollision = false;

        //BoxCast settings
        //Contains the bool value from cast
        private bool hitDetect;
        //Distance of casting
        readonly float maxDistance = 0.5f;
        //Number to reduce the size of the BoxCast
        readonly float subtractionNumber = 0.75f;
        //Stores the hit information
        RaycastHit hit;

        private Rigidbody myRigidbody;


        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (checkForCollision)
            {
                CheckWallCollision();
            }
        }

        void CheckWallCollision()
        {
            //(Physics.Raycast(transform.position - new Vector3(0, 0, 0.5f), Vector3.forward, out RaycastHit hit, 1.2f))
            hitDetect = Physics.BoxCast(transform.position, transform.localScale - new Vector3(subtractionNumber, subtractionNumber, subtractionNumber), transform.forward, out hit, transform.rotation, maxDistance);
            if (hitDetect)
            {
                if (hit.transform.CompareTag("CubeWall"))
                {
                    WallHit();
                }
                if (hit.transform.CompareTag("CubePickup"))
                {
                    PlayerController.Instance.AddCube(hit.transform.gameObject);
                }
            }
        }

        private void WallHit()
        {
            checkForCollision = false;
            gameObject.transform.parent = null;
            myRigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            myRigidbody.freezeRotation = true;
            PlayerController.Instance.LoseCube(gameObject);
            StartCoroutine(CubeDeactivation());
        }

        IEnumerator CubeDeactivation()
        {
            yield return new WaitForSeconds(2f);
            myRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            myRigidbody.freezeRotation = true;
            gameObject.SetActive(false);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            //Check if there has been a hit yet
            if (hitDetect)
            {
                //Draw a Ray forward from GameObject toward the hit
                Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
                //Draw a cube that extends to where the hit exists
                Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.localScale - new Vector3(subtractionNumber, subtractionNumber, subtractionNumber));
            }
            //If there hasn't been a hit yet, draw the ray at the maximum distance
            else
            {
                //Draw a Ray forward from GameObject toward the maximum distance
                Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
                //Draw a cube at the maximum distance
                Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, transform.localScale - new Vector3(subtractionNumber, subtractionNumber, subtractionNumber));
            }
        }
    }
}
