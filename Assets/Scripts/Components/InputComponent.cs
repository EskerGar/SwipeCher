using Arrow;
using Settings;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Components
{
    public class InputComponent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler
    {
        [SerializeField] private InputSettings inputSettings;
        [SerializeField] private ShootAreaController shootAreaController;
    
        private bool _isNearArcher;
        private Camera _camera;
        private float _touchTime;

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (FindDistance(GetTouchPoint(eventData)) <= inputSettings.NearDistanceToArcher)
                _isNearArcher = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(!_isNearArcher) return;
            var hitPoint = GetTouchPoint(eventData);
            if (FindDistance(hitPoint) < inputSettings.MinDirectionDistance) return;
            shootAreaController.AddArea(hitPoint);
            _isNearArcher = false;
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