using Arrow;
using Settings;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Components
{
    public class InputComponent : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler
    {
        [SerializeField] private InputSettings inputSettings;
        [SerializeField] private ShootAreaController shootAreaController;
        
        private Camera _camera;
        private float _touchTime;

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var hitPoint = GetTouchPoint(eventData);
            // Check on the desired distance
            if (FindDistance(hitPoint) < inputSettings.MinDirectionDistance) return;
            shootAreaController.AddArea(hitPoint);
        }
    

        public void OnPointerClick(PointerEventData eventData)
        {
            // Check on max tap time
            if(Time.time - _touchTime <= inputSettings.MaxTapTimeFromClear)
                shootAreaController.ClearAllAreas();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _touchTime = Time.time;
        }
    
        private void Start()
        {
            _camera = Camera.main;
        }

        // Get a touch position on the screen
        private Vector2 GetTouchPoint(PointerEventData eventData)
        {
            Physics.Raycast(_camera.ScreenPointToRay(eventData.position), out var hit);
            return hit.point;
        }
        
        // Find distance between archer and touch position
        private float FindDistance(Vector2 touchPosition)
        {
            return (touchPosition - (Vector2)shootAreaController.transform.position).magnitude;
        }
    }
}