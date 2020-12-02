using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/InputSettings", fileName = "InputSettings")]
    public class InputSettings : ScriptableObject
    {
        [Tooltip("Min desired distance for create shooting direction")][SerializeField] private float minDirectionDistance;
        [Tooltip("Max time after which tap become swipe")][SerializeField] private float maxTapTimeFromClear;
        

        public float MinDirectionDistance => minDirectionDistance;

        public float MaxTapTimeFromClear => maxTapTimeFromClear;
    }
}