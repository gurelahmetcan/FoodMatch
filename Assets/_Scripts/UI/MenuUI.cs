using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UIElements;

namespace FoodMatch
{
    public class MenuUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private RectTransform m_PlayButton;
        [SerializeField] private RectTransform m_StarAnim;

        #endregion

        #region Unity Methods

        private void Start()
        {
            m_PlayButton.DOScale(1.2f, 1f).SetLoops(-1, LoopType.Yoyo);
            m_StarAnim.DOLocalMoveX(Screen.width / 2f + 100f, 2.5f).SetEase(Ease.Linear).SetLoops(-1);
        }

        #endregion

        #region Public Methods

        public void OnPlayClick()
        {
            SceneManager.LoadScene("GameScene");
        }

        #endregion
    }
}

