using ScriptableObjects.EventChannels;
using UI;
using UnityEngine;

namespace Scene_Management
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private UILevel _uiLevel;
        
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
            _uiLevel.Init();
        }
    }
}
