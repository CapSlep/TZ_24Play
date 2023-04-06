using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] float inputSensitivity = 8f;

        private float xInputPosition;
        private bool playerCanMove = false;
        private InputReader inputReader;

        private void Start()
        {
            inputReader = GetComponent<InputReader>();
        }

        private void Update()
        {
            if (playerCanMove)
            {
                xInputPosition = inputReader.MoveComposite.x / Screen.width * inputSensitivity;
                PlayerController.Instance.PlayerXPosition(xInputPosition);
            }
        }

        public void PlayerCanMove(bool value)
        {
            playerCanMove = value;
        }
    }
}
