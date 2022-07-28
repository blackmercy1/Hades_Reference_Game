using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.JoyStick
{
    public class Joystick : MonoBehaviour, IPointerDownHandler , IPointerUpHandler, IDragHandler
    {
        [SerializeField] private GameObject _joystick;
        [SerializeField] private GameObject _joystickBackGround;
        [SerializeField] private GameObject _joyStick;
        public Vector2 JoyStickInputDirection => _joystickInputPosition;

        private Vector2 _joystickInputPosition;
        private Vector2 _joystickTouchPos;
        private Vector2 _joystickOriginalPos;
        
        private float _joystickRadius;
    
        private void Awake()
        {
            _joystickOriginalPos = _joystickBackGround.transform.position;
            _joystickRadius = _joystickBackGround.GetComponent<RectTransform>().sizeDelta.y / 2.5f;
            _joystickInputPosition = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _joystick.transform.position = eventData.position;
            _joystickBackGround.transform.position = eventData.position;
            _joystickTouchPos = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _joystickInputPosition = Vector2.zero;
            _joystick.transform.position = _joystickOriginalPos;
            _joystickBackGround.transform.position = _joystickOriginalPos;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var dragPosition = eventData.position;
            var joystickDist = Vector2.Distance(dragPosition, _joystickTouchPos);
            
            _joystickInputPosition = (dragPosition - _joystickTouchPos).normalized;
            _joystick.transform.position = joystickDist < _joystickRadius ? _joystickTouchPos + _joystickInputPosition * joystickDist :
                _joystick.transform.position = _joystickTouchPos + _joystickInputPosition * _joystickRadius;
        }
    }
}