using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject startPage;
        [SerializeField] GameObject endPage;

        public void StartPageController(bool value)
        {
            startPage.SetActive(!value);
        }
        public void GameOverPage()
        {
            startPage.SetActive(false);
            endPage.SetActive(true);
        }
    }
}
