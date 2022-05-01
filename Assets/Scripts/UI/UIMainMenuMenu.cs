using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIMainMenuMenu : MonoBehaviour
    {
        [SerializeField] private Button _playNextLevel;
        
        private void Start()
        {
            SetupButtons();
        }

        private void SetupButtons()
        {
            _playNextLevel.onClick.AddListener(OnPlayNextLevelButtonClicked);
        }
        
        private void OnPlayNextLevelButtonClicked()
        {
            _playNextLevel.gameObject.SetActive(false);
            // load next scene
        }

    }
}
