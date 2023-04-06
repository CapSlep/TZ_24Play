using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class SpawnPool : MonoBehaviour
    {
        [Header("Pool Options")]
        [Tooltip("Bool to determine, is this Pool can be auto expanded")]
        public bool autoExpand = true;
        [Tooltip("Amount of items in pool")]
        public int poolCount = 5;
        [Tooltip("Prefab of gameObject that will be spawned")]
        public GameObject prefab;
        [Tooltip("Holder for spawned gameObjects")]
        public GameObject holder;

        public PoolMono<CubeObject> pool;

        public static SpawnPool Instance { get; private set; }
        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.

            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            InitializeSpawnPools();
        }

        public void InitializeSpawnPools()
        {
            if (prefab != null)
            {
                pool = new PoolMono<CubeObject>(prefab.GetComponent<CubeObject>(), poolCount, holder.transform)
                {
                    autoExpand = autoExpand
                };
            }
        }

        public GameObject SpawnCube()
        {
            if (prefab != null)
            {
                CubeObject cubeObj = pool.GetFreeElement();
                
                cubeObj.transform.SetPositionAndRotation(holder.transform.position, new Quaternion(0, 0, 0, 0));
                cubeObj.gameObject.transform.SetParent(holder.transform);
                cubeObj.checkForCollision = true;
                return cubeObj.gameObject;
            }
            return null;
        }

    }
}
