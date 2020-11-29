using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/InputSettings", fileName = "InputSettings")]
    public class InputSettings : ScriptableObject
    {
        [SerializeField][Tooltip("How close to the archer you need to start drawing the direction")] private float nearDistanceToArcher;
        [SerializeField] private float minDirectionDistance;
        [SerializeField] private float tapTimeFromClear;

        public float NearDistanceToArcher => nearDistanceToArcher;

        public float MinDirectionDistance => minDirectionDistance;

        public float TapTimeFromClear => tapTimeFromClear;
    }
}