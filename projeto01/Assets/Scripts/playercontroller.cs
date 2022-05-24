using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed;
    private Controle _controle;
    private PlayerInput _playerInput;
    private Camera _mainCamera;
    private Rigidbody _rigidbody;

    private Vector2 _moveInput;

    private void OnEnable()
    {
        //inicializaçao de variavel
        _controle = new Controle();

        //Refencias dos componetes no mesmo objeto da unity
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        
        // referencia para a camare main guarda na classe camera
        _mainCamera = Camera.main;
        
        //atribuindo ao delegate do action triggered no player
        _playerInput.onActionTriggered += OnActionTriggered;
        
        
    }

    private void OnDisable()
    {
        
        _playerInput.onActionTriggered -= OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        // camparendo o nome da action que esta chegando com o nome da action de mover
        if (obj.action.name.CompareTo(_controle.Gameplay.Movement.name) == 0)
        {
            // 
            _moveInput = obj.ReadValue<Vector2>();
        }
        
        
    }

    private void Move()
    {
        // calcula o movimento no eixo da camera para o movimento frente/tras
        Vector3 moveVertical = _mainCamera.transform.forward * _moveInput.y;
        
        // calcula o movimento no eixo da camera para o movimento esquerda/direita
        Vector3 moverHorizontal = _mainCamera.transform.right * _moveInput.x;
        
        // adiciona a força no objeto atraves do rigidbory com intensidade definida por moverSpeed
        _rigidbody.AddForce((moveVertical + moverHorizontal) * moveSpeed * Time.fixedDeltaTime);
        
    }

    private void FixedUpdate()
    {
        Move();
    }
}