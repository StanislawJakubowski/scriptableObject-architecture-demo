using ScriptableObjects.EventChannels;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playNextLevel;
        
        [Header("Broadcasting on")]
        [SerializeField] private SceneEventChannelSO _loadScene;
        
        public void Init()
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
            _loadScene.RaiseEvent(SceneType.Level);
        }

    }
}
