using Services.PlayerInputs;
using UnityEngine;

namespace Mechanics.Players
{
    public class PlayerRotater
    {
        private readonly IPlayerInput _playerInput;
        private readonly float _rotateSpeed;
        private readonly Transform _transform;
        private readonly Transform _cameraTransform;

        public PlayerRotater(IPlayerInput playerInput, float rotateSpeed, Transform transform, Transform cameraTransform)
        {
            _playerInput = playerInput;
            _rotateSpeed = rotateSpeed;
            _transform = transform;
            _cameraTransform = cameraTransform;
        }
        public void UpdateLoop()
        {
            Vector2 rotateDirection = _playerInput.RotateDirection;
            float mouseX = rotateDirection.x * _rotateSpeed;
            float mouseY = rotateDirection.y * _rotateSpeed;

            _transform.Rotate(Vector3.up * mouseX);
            _cameraTransform.localRotation =
                Quaternion.Euler(_cameraTransform.localRotation.eulerAngles.x - mouseY, 0f, 0f);
        }
    }
}