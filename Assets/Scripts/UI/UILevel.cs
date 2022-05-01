using ScriptableObjects.EventChannels;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILevel : MonoBehaviour
    {
        [SerializeField] private Button _loadMainMenu;
        
        [Header("Broadcasting on")]
        [SerializeField] private SceneEventChannelSO _loadScene;
        
        public void Init()
        {
            SetupButtons();
        }

        private void SetupButtons()
        {
            _loadMainMenu.onClick.AddListener(OnLoadMainManuButtonClicked);
        }
        
        private void OnLoadMainManuButtonClicked()
        {
            _loadMainMenu.gameObject.SetActive(false);
            _loadScene.RaiseEvent(SceneType.MainMenu);
        }
    }
    
}
