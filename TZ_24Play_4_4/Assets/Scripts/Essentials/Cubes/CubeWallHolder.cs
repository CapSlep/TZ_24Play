using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class CubeWallHolder : MonoBehaviour
    {
        [SerializeField] GameObject currentWall;

        public void OrderNewWall()
        {
            currentWall.SetActive(false);
            currentWall = WallsManager.Instance.GetFreeWall(transform);
        }
    }
}
