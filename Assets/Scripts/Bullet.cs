using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    private Vector2 _direction;
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        transform.Translate(_direction * Time.deltaTime);
    }
}