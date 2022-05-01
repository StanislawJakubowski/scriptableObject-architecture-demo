
using ScriptableObjects.EventChannels;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILevel : MonoBehaviour
    {
        [SerializeField] private Button _loadMainManu;
        
        [Header("Broadcasting on")]
        [SerializeField] private SceneEventChannelSO _loadScene;
        
        public void Init()
        {
            SetupButtons();
        }

        private void SetupButtons()
        {
            _loadMainManu.onClick.AddListener(OnLoadMainManuButtonClicked);
        }
        
        private void OnLoadMainManuButtonClicked()
        {
            _loadMainManu.gameObject.SetActive(false);
            _loadScene.RaiseEvent(SceneType.MainManu);
        }
    }
    
}
