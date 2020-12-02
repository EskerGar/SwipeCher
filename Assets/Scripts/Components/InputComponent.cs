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
            if (FindDistance(hitPoint) < inputSettings.MinDirectionDistance) return;
            shootAreaController.AddArea(hitPoint);
        }
    

        public void OnPointerClick(PointerEventData eventData)
        {
            if(Time.time - _touchTime >= inputSettings.TapTimeFromClear)
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

        private Vector2 GetTouchPoint(PointerEventData eventData)
        {
            Physics.Raycast(_camera.ScreenPointToRay(eventData.position), out var hit);
            return hit.point;
        }
        private float FindDistance(Vector2 touchPosition)
        {
            return (touchPosition - (Vector2)shootAreaController.transform.position).magnitude;
        }
    }
}