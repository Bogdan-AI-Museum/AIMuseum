using UnityEngine;

namespace Services.PlayerInputs
{
    public interface IPlayerInput
    {
        Vector2 RotateDirection { get; }
        Vector2 MoveDirection { get; }
        bool IsJump { get; }
    }
}