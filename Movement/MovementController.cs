using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class MovementController : MonoBehaviour, IAction
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private ActionScheduler _actionScheduler;
    
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _actionScheduler = GetComponent<ActionScheduler>();
        }
        private void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(_navMeshAgent.velocity);
            _animator.SetFloat("forwardSpeed", localVelocity.z);
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

        public void Stop()
        {
            _navMeshAgent.isStopped = true;
        }

        public void Cancel()
        {
            Stop();
        }
    }
}
