using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TZ.Input
{
    public class InputReader : MonoBehaviour, PlayerActions.IGameplayActions
    {
        public Vector2 MoveComposite;

        public GameEvent OnPlayerCanMove;

        private PlayerActions playerActions;

        private void OnEnable()
        {
            playerActions = new PlayerActions();    
            playerActions.Gameplay.SetCallbacks(this);
            playerActions.Gameplay.Enable();
        }

        private void OnDisable()
        {
            playerActions.Gameplay.Disable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MoveComposite = context.ReadValue<Vector2>();
        }

        public void OnPrimaryTouch(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                OnPlayerCanMove.TriggerEvent(false);
                return;
            }

            OnPlayerCanMove.TriggerEvent(true);
        }

        public void CutPlayerControlls()
        {
            playerActions.Gameplay.Disable();
        }
    }

}