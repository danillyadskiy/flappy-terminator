using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ShipCollisionHandler))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private float _delayBetweenShot;
    
    private ShipCollisionHandler _handler;

    public void Operate()
    {
        StartCoroutine(MakeShot());
    }
    
    private void Awake()
    {
        _handler = GetComponent<ShipCollisionHandler>();
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
        if (interactable is ShipBullet)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Operate();
    }

    private IEnumerator MakeShot()
    {
        while (enabled)
        {
            Bullet bullet = Instantiate(_bullet, transform.position, _bullet.transform.rotation);
            bullet.SetDirection(Vector2.up);
            
            yield return new WaitForSeconds(_delayBetweenShot);
        }
    }
}
