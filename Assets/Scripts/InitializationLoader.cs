using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class InitializationLoader : MonoBehaviour
{
    [SerializeField] private AssetReference _persistentManagersScene;
     
    private void Start()
    {
        _persistentManagersScene.LoadSceneAsync(LoadSceneMode.Additive).Completed += LoadEventChannel;
    }

    private void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
    {
        SceneManager.UnloadSceneAsync(0);
    }
        
}
