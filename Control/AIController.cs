using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance;
        private GameObject _player;
        
        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            
        }
    }
}