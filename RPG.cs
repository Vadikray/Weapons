using UnityEngine;

public class RPG : Weapon
{
    [SerializeField] private float _cooldown;
    
    private bool _recharge = false;

    public override void Shoot(Transform shootPoint)
    {
        if (!_recharge)
        {
            _recharge = !_recharge;
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            Invoke("ReloadWeapon", _cooldown);
        }
    }
    
    private void ReloadWeapon()
    {
        _recharge = !_recharge;
    }
}