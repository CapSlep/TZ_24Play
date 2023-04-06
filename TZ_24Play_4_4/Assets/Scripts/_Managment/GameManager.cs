using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

namespace TZ
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject warpEffect;

        public void GameOver()
        {
            Debug.Log("End of The Game");
            warpEffect.SetActive(false);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void WarpEffectController(bool value)
        {
            warpEffect.SetActive(value);
        }
    }
}
