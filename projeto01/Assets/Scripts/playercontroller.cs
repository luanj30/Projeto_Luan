using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    public TMP_Text coninText;
    public int coins = 0;
    public float moveSpeed;
    public float maxVelocity;

    public float rayDistance;
    public LayerMask groundLayer;
    public float jampForce;
    
    private Controle _controle;
    private PlayerInput _playerInput;
    private Camera _mainCamera;
    private Rigidbody _rigidbody;

    private Vector2 _moveInput;

    private bool _isGrounded;

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

        if (obj.action.name.CompareTo(_controle.Gameplay.Jamp.name) == 0)
        {
            if (obj.performed) Jamp();
        }

    }

    private void Move()
    {
        Vector3 camForward = _mainCamera.transform.forward;
        camForward.y = 0;
        // calcula o movimento no eixo da camera para o movimento frente/tras
        Vector3 moveVertical = camForward * _moveInput.y;

        Vector3 camRight = _mainCamera.transform.right;
        camRight.y = 0;
        // calcula o movimento no eixo da camera para o movimento esquerda/direita
        Vector3 moverHorizontal = camRight * _moveInput.x;
        
        // adiciona a força no objeto atraves do rigidbory com intensidade definida por moverSpeed
        _rigidbody.AddForce((moveVertical + moverHorizontal) * moveSpeed * Time.fixedDeltaTime);
        
    }

    private void FixedUpdate()
    {
        Move();
        LimitVelocity();
    }

    private void LimitVelocity()
    {
        Vector3 velocity = _rigidbody.velocity;

        if (Mathf.Abs(velocity.x) > maxVelocity) velocity.x = Mathf.Sign(velocity.x) * maxVelocity;

        velocity.z = Mathf.Clamp(value: velocity.z, min: -maxVelocity, maxVelocity);

        _rigidbody.velocity = velocity;

    }
    private void Jamp()
    {
      if(_isGrounded) _rigidbody.AddForce(Vector3.up * jampForce, ForceMode.Impulse);  
    }
    
    // jogador pulando...

    private void CheckGround()
    {
        _isGrounded = Physics.Raycast(origin: transform.position, Vector3.down, rayDistance, (int) groundLayer);
    }

    private void Update()
    {
        CheckGround();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(start:transform.position, dir: Vector3.down * rayDistance,Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            PayerObserverManeger.PlayerCoinsChanged(coins);
            Destroy(other.gameObject);
        }

        
    }
}