using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private Camera _mainCamera;
        private MovementController _movementController;
        private FighterController _fighterController;

        private void Start()
        {
            _mainCamera = Camera.main;
            _movementController = GetComponent<MovementController>();
            _fighterController = GetComponent<FighterController>();
        }
        
        private void Update()
        { 
            if (InteractWithCombat()) return;

            InteractWithMovement();
        }

        private bool InteractWithCombat()
        {
            foreach (RaycastHit hit in GetRaycastHits())
            {
                if (hit.transform == null) continue;
                
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();

                if (combatTarget == null) continue;

                if (Input.GetMouseButtonDown(0)) _fighterController.StartAttackAction(combatTarget);

                return true;
            }

            return false;
        }
        
        private bool InteractWithMovement()
        {
            foreach (RaycastHit hit in GetRaycastHits())
            {
                if (!HitHasTransform(hit)) continue;

                if (!hit.transform.gameObject.CompareTag("CanMove")) continue;
                
                if (Input.GetMouseButton(0)) _movementController.StartMovementAction(hit.point);

                return true;
            }
            
            return false;
        }

        private Ray GetMouseRay()
        {
            return _mainCamera.ScreenPointToRay(Input.mousePosition);
        }

        private RaycastHit[] GetRaycastHits()
        {
            RaycastHit[] hits = new RaycastHit[5];
            Physics.RaycastNonAlloc(GetMouseRay(), hits);

            return hits;
        }

        private static bool HitHasTransform(RaycastHit hit)
        {
            return hit.transform != null;
        }
    }
}