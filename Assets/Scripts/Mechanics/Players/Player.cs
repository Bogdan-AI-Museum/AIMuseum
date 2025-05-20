using Installers;
using Services.PlayerInputs;
using UnityEngine;
using Zenject;

namespace Mechanics.Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private Transform cameraTransform;
        private PlayerRotater _rotater;
        private PlayerMover _mover;
        private bool _isPause;
        private MuseumScreen _museumScreen;

        [Inject]
        private void Construct(IPlayerInput playerInput, MuseumConfig config, MuseumScreen museumScreen)
        {
            _museumScreen = museumScreen;
            PlayerConfig playerConfig = config.player;
            _mover = new PlayerMover(playerInput, playerConfig.moveSpeed, transform, controller);
            _rotater = new PlayerRotater(playerInput, playerConfig.rotateSpeed, transform, cameraTransform);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isPause = _isPause == false;
                _museumScreen.SetPauseShowCurrentItemText(_isPause);
                Debug.Log("Set pause rotate: " + _isPause);
            }

            if (_isPause == false)
            {
                _rotater.UpdateLoop();
                _mover.UpdateLoop();
            }
        }
    }
}