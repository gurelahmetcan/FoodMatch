using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoodMatch
{
    public class IngameUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LevelSuccessUI m_levelSuccessUI;

        #endregion

        #region Unity Methods

        private void Start()
        {
            GameManager.OnGameFinished += OnGameFinished;
        }

        private void OnDestroy()
        {
            GameManager.OnGameFinished -= OnGameFinished;
        }

        #endregion

        #region Public Methods

        public void OnRestartClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            m_levelSuccessUI.ClosePanel();
        }

        #endregion

        #region Private Methods

        private void OnGameFinished(bool isWin, int currentLevel)
        {
            m_levelSuccessUI.OpenPanel(isWin, currentLevel);
        }

        #endregion
    }
}