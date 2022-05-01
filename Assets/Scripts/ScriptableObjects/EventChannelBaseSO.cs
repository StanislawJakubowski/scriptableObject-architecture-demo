using UnityEngine;

namespace ScriptableObjects
{
    public class EventChannelBaseSO : ScriptableObject
    {
        #if UNITY_EDITOR
            [TextArea] public string _description = string.Empty;
        #endif
    }
}
