using UnityEngine;
using UnityEngine.Serialization;

public class ShipTracker : MonoBehaviour
{
    [FormerlySerializedAs("_bird")] [SerializeField] private Ship _ship;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _ship.transform.position.x + _xOffset;
        transform.position = position;
    }
}
