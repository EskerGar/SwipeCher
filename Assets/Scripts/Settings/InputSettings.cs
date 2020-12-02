using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/InputSettings", fileName = "InputSettings")]
    public class InputSettings : ScriptableObject
    {
        [SerializeField] private float minDirectionDistance;
        [SerializeField] private float maxTapTimeFromClear;
        

        public float MinDirectionDistance => minDirectionDistance;

        public float MaxTapTimeFromClear => maxTapTimeFromClear;
    }
}