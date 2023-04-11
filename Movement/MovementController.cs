using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class MovementController : MonoBehaviour, IAction
    {
        private NavMeshAgent _navMeshAgent;
        private ActionScheduler _actionScheduler;
    
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _actionScheduler = GetComponent<ActionScheduler>();
        }

        public void StartMovementAction(Vector3 point)
        {
            _actionScheduler.StartAction(this);
            MoveTo(point);
        }
        
        public void MoveTo(Vector3 point)
        {
            _navMeshAgent.destination = point;
            _navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}
