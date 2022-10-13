using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShotMergerClone.UI
{
    public class LevelCounterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentLevelText;

        private void Start()
        {
            currentLevelText.text = $"Level {SceneManager.GetActiveScene().buildIndex + 1}";
        }
    }
}