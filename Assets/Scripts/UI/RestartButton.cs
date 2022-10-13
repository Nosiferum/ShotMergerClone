using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShotMergerClone.UI
{
    public class RestartButton : MonoBehaviour
    {
        private Button retryButton;

        private void Awake()
        {
            retryButton = GetComponent<Button>();
            retryButton.onClick.AddListener(Retry);
        }

        private void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

