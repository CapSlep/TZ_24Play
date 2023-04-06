using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class CubePickup : MonoBehaviour
    {
        [SerializeField] float xPosRange = 0.4f;

        public void GeneratePosition()
        {
            var newXPos = Random.Range(-xPosRange, xPosRange);
            transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
            if(!gameObject.activeInHierarchy)
                gameObject.SetActive(true);
        }
    }
}
