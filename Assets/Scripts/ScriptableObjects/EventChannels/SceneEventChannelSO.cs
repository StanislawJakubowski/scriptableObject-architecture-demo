using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.EventChannels
{
    public enum SceneType
    {
        MainMenu,
        Level
    }

    
    [CreateAssetMenu(menuName = "Events/Load Event Channel")]
    public class SceneEventChannelSO : EventChannelBaseSO
    {
        public UnityAction<SceneType> OnLoadingRequested;
        
        public void RaiseEvent(SceneType sceneToLoad)
        {
            if (OnLoadingRequested != null)
            {
                OnLoadingRequested.Invoke(sceneToLoad);
            }
            else
            {
                Debug.LogWarning("A Scene loading was requested, but nobody picked it up.");
            }
        }
    }
}
