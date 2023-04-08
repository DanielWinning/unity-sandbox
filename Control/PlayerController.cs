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
        private NavMeshAgent _navMeshAgent;
        private Fighter _fighter;
        private float _defaultSpeed;
        private const float SprintSpeed = 15f;

        private void Start()
        {
            _mainCamera = Camera.main;
            _movementController = gameObject.AddComponent<MovementController>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _defaultSpeed = _navMeshAgent.speed;
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

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Sprint();
            }
            else
            {
                StandardSpeed();
            }
        }

        private Ray GetMouseRay()
        {
            return _mainCamera.ScreenPointToRay(Input.mousePosition);
        }
        
        private void Sprint()
        {
            _navMeshAgent.speed = SprintSpeed;
        }

        private void StandardSpeed()
        {
            _navMeshAgent.speed = _defaultSpeed;
        }
    }
}