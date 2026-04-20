using UnityEngine;
using UnityEngine.Events;

public abstract class BulletShooter : MonoBehaviour
{
    public event UnityAction FiredBullet;

    protected void NotifyFire()
    {
        FiredBullet?.Invoke();
    }
}