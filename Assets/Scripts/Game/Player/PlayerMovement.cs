using UnityEngine;
using UnityEngine.UIElements;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private float _speed = 4f;
        private Transform _cashedTransform;
        private Camera _mainCamera;

        private void Awake()
        {
            _cashedTransform = transform;
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(x: horizontal, y: vertical);
            Vector3 moveDelta = (Vector3)(direction * (_speed * Time.deltaTime));
            _cashedTransform.position += moveDelta;

            _playerAnimation.SetSpeed(direction.magnitude);

        }

        private void Rotate()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;

            Vector3 direction = worldPoint - _cashedTransform.position;
            _cashedTransform.up = direction;
        }
    }
}
