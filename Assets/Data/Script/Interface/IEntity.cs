using UnityEngine;
using UnityEngine.Events;

public interface IEntity
{
    public Vector3 Position { get; }
    public GameObject GameObject { get; }

    public void GetDamage(float damage);
    public void ChangePosition(Vector3 position);
}
