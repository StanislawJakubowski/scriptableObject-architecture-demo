using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Scene_Management
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _mainMenuScene;
        
        private AsyncOperationHandle<SceneInstance> _handle;
        private AssetReference _currentlyLoadedScene;
        private bool _isGamePlaySceneLoaded;

        private void Start()
        {
            LoadScene(_mainMenuScene);
        }

        private void LoadScene(AssetReference sceneToLoad)
        {
            StartCoroutine(LoadSceneRoutine(sceneToLoad));
        }
        
        private IEnumerator LoadSceneRoutine(AssetReference sceneToLoad)
        {
            yield return UnloadPreviousSceneIfNecessaryRoutine();
            
            sceneToLoad.LoadSceneAsync(LoadSceneMode.Additive).Completed += SceneLoadComplete;
            _currentlyLoadedScene = sceneToLoad;
            
        }
        
        private IEnumerator UnloadPreviousSceneIfNecessaryRoutine()
        {
            if (_currentlyLoadedScene != null && _handle.IsValid())
            {
                yield return _currentlyLoadedScene.UnLoadScene();
            }
        }
        
        private void SceneLoadComplete(AsyncOperationHandle<SceneInstance> obj)
        {
            _handle = obj;
            SceneManager.SetActiveScene(obj.Result.Scene);
        }
    }
}
