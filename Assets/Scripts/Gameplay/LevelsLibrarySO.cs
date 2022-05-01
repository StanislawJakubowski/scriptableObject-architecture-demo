using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay
{
    [Serializable]
    public class GameLevel
    {
        [SerializeField] private AssetReference _scene;
        public AssetReference Scene => _scene;
    }

    [CreateAssetMenu(fileName = "Levels Library", menuName  = "Levels Library")]
    public class LevelsLibrarySO : ScriptableObject
    {
        [SerializeField] private GameLevel[] _gameLevels;

        public AssetReference GetGameLevelByIndex(int index)
        {
            return _gameLevels[index].Scene;
        }
    }
}
