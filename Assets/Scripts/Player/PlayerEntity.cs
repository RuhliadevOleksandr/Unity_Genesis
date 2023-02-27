using Core.Enums;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private Direction _direction;
        
        private Rigidbody2D _rigidbody;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 direction)
        {
            SetDirection(direction.x);
            Vector2 position = _rigidbody.position;
            position += direction.normalized * (_moveSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(position);
        }

        private void SetDirection(float direction)
        {
            if ((_direction == Direction.Right && direction < 0) || 
                (_direction == Direction.Left && direction > 0))
                Flip();
        }

        private void Flip()
        {
            transform.Rotate(0,180,0);
            _direction = _direction == Direction.Right ? Direction.Left : Direction.Right;
        }
    }
}
