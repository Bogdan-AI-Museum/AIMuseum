using Services.PlayerInputs;
using UnityEngine;

namespace Mechanics.Players
{
    public class PlayerMover 
    {
        private readonly IPlayerInput _playerInput;
        private readonly float _moveSpeed;
        private readonly Transform _transform;
        private readonly CharacterController _controller;
        private readonly float _jumpHeight;
        private readonly float _gravity;
        private Vector3 _velocity;

        public PlayerMover(IPlayerInput playerInput, float moveSpeed, Transform transform, CharacterController controller)
        {
            _playerInput = playerInput;
            _moveSpeed = moveSpeed;
            _transform = transform;
            _controller = controller;
        }

        public void UpdateLoop()
        {
            Vector2 direction = _playerInput.MoveDirection;
            Vector3 move = _transform.right * direction.x + _transform.forward * direction.y;
            _controller.Move(move * (_moveSpeed * Time.deltaTime));
        }
    }
}