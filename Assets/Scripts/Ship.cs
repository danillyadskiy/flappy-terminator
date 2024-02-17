using System;
using UnityEngine;

[RequireComponent(typeof(ShipMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(ShipCollisionHandler))]
public class Ship : MonoBehaviour
{
    private ShipMover _shipMover;
    private ScoreCounter _scoreCounter;
    private ShipCollisionHandler _handler;

    public event Action GameOver;

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
        if (interactable is Pipe)
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

    public void Reset()
    {
        _scoreCounter.Reset();
        _shipMover.Reset();
    }
}
