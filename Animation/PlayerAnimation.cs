using UnityEngine;
using UnityEngine.AI;

namespace RPG.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;

        public void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(_navMeshAgent.velocity);
            _animator.SetFloat("forwardSpeed", localVelocity.z);
        }
    }
}