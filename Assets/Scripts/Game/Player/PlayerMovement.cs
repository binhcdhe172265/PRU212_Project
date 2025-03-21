﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    public Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetPlayerPosition();
        RotateInDirectionOfInput();
        setupAnimation();
    }

    private void SetPlayerPosition()
    {
        // Smooth input
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);

        // Tính vị trí đích của player
        Vector2 targetPosition = _rigidbody.position + _smoothedMovementInput * _speed * Time.fixedDeltaTime;

        // Giới hạn vị trí Y trong phạm vi từ -10 đến 10
        targetPosition.y = Mathf.Clamp(targetPosition.y, -10f, 10f);

        // Di chuyển player đến vị trí mới
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

    private void setupAnimation()
    {
        bool isMoving = _movementInput != Vector2.zero;
        _animator.SetBool("IsMoving", isMoving);
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
