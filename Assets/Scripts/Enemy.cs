using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delayBetweenShot;

    public void Operate()
    {
        StartCoroutine(MakeShot());
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
