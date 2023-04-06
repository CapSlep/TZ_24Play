using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TZ
{
    public class Track : MonoBehaviour
    {
        [SerializeField] float zSpawnPos = 100f;
        [SerializeField] float tracksMoveSpeed = 9.0f;

        public UnityEvent onResetPosition;

        private bool canMove;
        // Update is called once per frame
        void Update()
        {
            if (canMove)
            {
                if(transform.position.z < -20)
                {
                    ResetPosition();
                }
                var newZPos = transform.position.z - 1f;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, newZPos), tracksMoveSpeed * Time.deltaTime);
            }
        }

        public virtual void ResetPosition()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zSpawnPos);
            onResetPosition.Invoke();

        }

        public void MoveTrack(bool value)
        {
            canMove = value;
        }
    }
}
