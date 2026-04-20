using UnityEngine;

public class PlayerShot : BulletShooter
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NotifyFire();
        }
    }
}