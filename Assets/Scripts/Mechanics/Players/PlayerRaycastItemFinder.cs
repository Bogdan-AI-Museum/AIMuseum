using Installers;
using UnityEngine;
using Zenject;

namespace Mechanics.Players
{
    public class PlayerRaycastItemFinder : MonoBehaviour
    {
        [SerializeField] private float raycastDistance = 10f;
        private Camera _camera;
        private MuseumScreen _museumScreen;

        [Inject]
        private void Construct(MuseumScreen museumScreen)
        {
            _museumScreen = museumScreen;
        }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
            {
                if (hit.collider.TryGetComponent(out Item item))
                {
                    _museumScreen.SetCurrentItemText(item.Name);
                }
                else
                {
                    _museumScreen.SetEmptyCurrentItemText();
                }
            }
        }
    }
}