using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TZ
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;

        [Header("Player Settings")]
        [Tooltip("Player horizontal slide speed")]
        public float playerHorizontalSpeed = 15f;
        [Tooltip("Borders in wich player is allowed to slide left and right")]
        [SerializeField] float border = 2.025f;
        [SerializeField] GameObject playerRepresentative;

        [Header("Player Cubes Settings")]
        [Tooltip("The number of cubes allowed")]
        [SerializeField] int maxCubes = 7;
        [Tooltip("list of cubes that the player has")]
        [SerializeField] List<GameObject> activeCubes;

        [Header("Events")]
        public GameEvent gameOverEvent;

        private int activeCubesNumber = 1;
        private bool canMove = false;
        private Vector3 playerXPos;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            playerXPos = new Vector3(0f, transform.position.y, transform.position.z);
        }

        private void Update()
        {
            if (canMove)
                transform.position = Vector3.MoveTowards(transform.position, playerXPos, playerHorizontalSpeed * Time.deltaTime);
        }

        public void AddCube(GameObject cube)
        {
            if(activeCubesNumber != maxCubes)
            {
                cube.SetActive(false);
                activeCubesNumber = activeCubes.Count;
                foreach (var cub in activeCubes)
                {
                    cub.transform.localPosition = new Vector3(cub.transform.localPosition.x, cub.transform.localPosition.y + 1, cub.transform.localPosition.z);
                }
                playerRepresentative.transform.localPosition = new Vector3(playerRepresentative.transform.localPosition.x, playerRepresentative.transform.localPosition.y + 1, playerRepresentative.transform.localPosition.z);
                activeCubes.Add(SpawnPool.Instance.SpawnCube());
                activeCubesNumber = activeCubes.Count;
            }
        }

        public void LoseCube(GameObject cube)
        {
            activeCubes.Remove(cube);
            activeCubesNumber = activeCubes.Count;
            if (activeCubesNumber == 0)
            {
                transform.position = new Vector3(transform.position.x, -1, transform.position.z);
                gameOverEvent.TriggerEvent();
            }
        }

        public void PlayerXPosition(float xPos)
        {
            var newPlayerXPos = transform.position.x + xPos;
            newPlayerXPos = Mathf.Clamp(newPlayerXPos, -border, border);
            playerXPos = new Vector3(newPlayerXPos, transform.position.y, transform.position.z);
        }

        public void PlayerCanMove(bool value)
        {
            canMove = value;
        }
    }
}
