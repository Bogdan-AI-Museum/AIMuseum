using UnityEngine;

namespace Services.PlayerInputs
{
    public class PcPlayerInput : IPlayerInput
    {
        public Vector2 RotateDirection 
            => new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        public Vector2 MoveDirection
            => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        public bool IsJump => Input.GetButtonDown("Jump");
    }
}