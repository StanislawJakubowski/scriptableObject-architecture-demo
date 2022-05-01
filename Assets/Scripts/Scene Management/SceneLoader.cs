using System;
using System.Collections;
using Gameplay;
using ScriptableObjects.EventChannels;
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
        [SerializeField] private LevelsLibrarySO _levelsLibrary;

        [Header("Listening to")]
        [SerializeField] private SceneEventChannelSO _loadScene;

        [Header("Broadcasting on")]
        [SerializeField] private VoidEventChannelSO _onSceneReady;
        
        private AsyncOperationHandle<SceneInstance> _handle;
        private AssetReference _currentlyLoadedScene;
        private bool _isGamePlaySceneLoaded;
        
        private void OnEnable()
        {
            _loadScene.OnLoadingRequested += LoadSceneEventRaised;
        }

        private void OnDisable()
        {
            _loadScene.OnLoadingRequested -= LoadSceneEventRaised;
        }
        
        private void LoadSceneEventRaised(SceneType sceneType)
        {
            if (sceneType == SceneType.MainMenu)
            {
                LoadMainMenu();
                return;
            }

            LoadNextLevel();
        }
        
        private void Start()
        {
            LoadMainMenu();
        }

        private void LoadMainMenu()
        {
            LoadScene(_mainMenuScene);
        } 
        
        private void LoadNextLevel()
        {
            AssetReference sceneToLoad = _levelsLibrary.GetGameLevelByIndex(GetNextLevelSceneName());
            LoadScene(sceneToLoad);
            
            int GetNextLevelSceneName()
            {
                // get next level, use for example save system
                return 0;
            }
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
            _onSceneReady.RaiseEvent();
        }
    }
}
