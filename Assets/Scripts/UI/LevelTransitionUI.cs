using ShotMergerClone.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Twenty.UI
{
    public class LevelTransitionUI : MonoBehaviour
    {
        [Header("Level End")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;

        [Header("Buttons")]
        [SerializeField] private Button nextButton;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button levelRetryButton;

        private void Awake()
        {
            if (nextButton != null)
                nextButton.onClick.AddListener(NextLevel);
            if (retryButton != null)
                retryButton.onClick.AddListener(Retry); 
            if (levelRetryButton != null)
                levelRetryButton.onClick.AddListener(LevelRetry);
        }

        private void NextLevel()
        {
            //SceneManager.LoadScene(1);
            nextButton.interactable = false;
        }

        private void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            retryButton.interactable = false;
        } 
        
        private void LevelRetry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            levelRetryButton.interactable = false;
        }

        private void ShowWinUI()
        {
            winPanel.SetActive(true);
        }

        private void ShowLoseUI()
        {
            losePanel.SetActive(true);
        }

        private void OnEnable()
        {
            GameManager.onLevelSuccess += ShowWinUI;
            GameManager.onLevelFail += ShowLoseUI;
        }

        private void OnDisable()
        {
            GameManager.onLevelSuccess -= ShowWinUI;
            GameManager.onLevelFail -= ShowLoseUI;
        }
    }
}