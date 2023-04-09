using RPG.Combat;
using RPG.Movement;
using UnityEngine;

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
            _movementController = GetComponent<MovementController>();
            _fighter = GetComponent<Fighter>();
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

                if (Input.GetMouseButtonDown(0)) _fighter.Attack(combatTarget);

                return true;
            }

            return false;
        }
        
        private bool InteractWithMovement()
        {
            foreach (RaycastHit hit in GetRaycastHits())
            {
                if (hit.transform != null && hit.transform.gameObject.CompareTag("CanMove"))
                {
                    if (Input.GetMouseButton(0))
                    {
                        _movementController.StartMoving(hit.point);
                        
                        if (_fighter.HasTarget()) _fighter.ClearTarget();
                    }

                    return true;
                }
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
    }
}