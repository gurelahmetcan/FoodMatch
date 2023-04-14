using System;
using System.Collections;
using System.Collections.Generic;
using FoodMatch;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace FoodMatch
{
    public class LevelSuccessUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TextMeshProUGUI m_LevelText;
        
        [SerializeField] private Sprite m_WinImage;
        [SerializeField] private Sprite m_LoseImage;
        [SerializeField] private List<Image> m_StarSprites;

        [SerializeField] private Image m_BGImage;
        [SerializeField] private Sprite m_WinBg;
        [SerializeField] private Sprite m_LoseBg;

        #endregion

        #region Unity Methods

        #endregion

        #region Public Methods

        public void OpenPanel(bool isWin, int currentLevel)
        {
            gameObject.SetActive(true);

            var text = isWin ? "Success" : "Failed";
            m_LevelText.text = $"Level {currentLevel} {text}";

            foreach (var starImage in m_StarSprites)
            {
                starImage.sprite = isWin ? m_WinImage : m_LoseImage;
            }

            m_BGImage.sprite = isWin ? m_WinBg : m_LoseBg;
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}

