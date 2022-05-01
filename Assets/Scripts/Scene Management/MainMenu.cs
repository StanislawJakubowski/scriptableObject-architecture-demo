using ScriptableObjects.EventChannels;
using UI;
using UnityEngine;

namespace Scene_Management
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private UIMainMenu _uiMainMenu;
        
        [Header("Listening to")]
        [SerializeField] private VoidEventChannelSO _onSceneReady;
        
        private void OnEnable()
        {
            _onSceneReady.OnEventRaised += SceneReadyEventRaised;
        }
        
        private void OnDisable()
        {
            _onSceneReady.OnEventRaised -= SceneReadyEventRaised;
        }
        
        private void SceneReadyEventRaised()
        {
            _uiMainMenu.Init();
        }
    }
}
