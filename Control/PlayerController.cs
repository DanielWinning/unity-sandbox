using RPG.Combat;
using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private Camera _mainCamera;
        private MovementController _movementController;
        private Fighter _fighter;

        private void Start()
        {
            _mainCamera = Camera.main;
            _movementController = gameObject.AddComponent<MovementController>();
            _fighter = GetComponent<Fighter>();
        }
        
        private void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = new RaycastHit[5];
            Physics.RaycastNonAlloc(GetMouseRay(), hits);

            foreach (RaycastHit hit in hits)
            {
                // I don't like this double null check
                if (hit.transform == null) continue;
                
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();

                if (combatTarget == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    _fighter.Attack(combatTarget);
                }
            }
        }
        
        private void InteractWithMovement()
        {
            RaycastHit hitInfo;
            Physics.Raycast(GetMouseRay(), out hitInfo);

            if (Input.GetMouseButton(0))
            {
                _movementController.MoveTo(hitInfo.point);
            }
        }

        private Ray GetMouseRay()
        {
            return _mainCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
}