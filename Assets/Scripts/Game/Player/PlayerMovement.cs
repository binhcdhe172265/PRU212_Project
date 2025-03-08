using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       
        SetPlayerPosition();
        RotateInDirectionOfInput();
    }

    private void SetPlayerPosition()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);  

        Vector2 targetPosition = _rigidbody.position + _smoothedMovementInput * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(targetPosition);
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(_movementInput.y, _movementInput.x) * Mathf.Rad2Deg;
            float angle = Mathf.MoveTowardsAngle(
                _rigidbody.rotation,
                targetAngle,
                _rotationSpeed * Time.deltaTime);  
            _rigidbody.MoveRotation(angle);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
