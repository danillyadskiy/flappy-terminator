using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ShipMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(ShipCollisionHandler))]
public class Ship : MonoBehaviour
{
    [SerializeField] private ShipBullet _bullet;
    [SerializeField, Min(0)] private float _bulletSpeed;
    
    private ShipMover _shipMover;
    private ScoreCounter _scoreCounter;
    private ShipCollisionHandler _handler;

    public event Action GameOver;
    
    public void Reset()
    {
        _scoreCounter.Reset();
        _shipMover.Reset();
    }

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<ShipCollisionHandler>();
        _shipMover = GetComponent<ShipMover>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            GameOver?.Invoke();
        }
        
        if (interactable is EnemyBullet)
        {
            GameOver?.Invoke();
        }
        
        if (interactable is KillBox)
        {
            GameOver?.Invoke();
        }

        else if(interactable is ScoreZone) 
        {
            _scoreCounter.Add();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MakeShot();
        }
    }

    private void MakeShot()
    {
        Bullet bullet = Instantiate(_bullet, transform.position, _bullet.transform.rotation);
        bullet.SetDirection(Vector2.up * _bulletSpeed);
    }
}
