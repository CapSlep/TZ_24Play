using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class WallsManager : MonoBehaviour
    {
        public static WallsManager Instance;

        [SerializeField] List<GameObject> wallsLibrary;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public GameObject GetFreeWall(Transform newParent)
        {
            List<GameObject> listOfFreeWalls = new();
            foreach (GameObject wall in wallsLibrary)
            {
                if (!wall.activeInHierarchy)
                {
                    listOfFreeWalls.Add(wall);
                }
            }
            var chosenWall = listOfFreeWalls[Random.Range(0, listOfFreeWalls.Count)];
            chosenWall.transform.parent = newParent;
            chosenWall.transform.SetPositionAndRotation(newParent.position, new Quaternion(0, 0, 0, 0));
            chosenWall.gameObject.SetActive(true);
            return chosenWall;
        }
    }
}
