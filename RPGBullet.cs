using UnityEngine;

public class RPGBullet : Bullet
{
    [SerializeField] private float _radiusExplosion;
    [SerializeField] private LayerMask _interaction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
    }

    private void Explode()
    {
        Destroy(gameObject);
        var hitCollides = Physics2D.OverlapCircleAll(transform.position, _radiusExplosion, _interaction);

        if (hitCollides == null)
            return;

        foreach (var hitCollide in hitCollides)
        {
            if (!hitCollide.TryGetComponent(out Enemy enemy))
                continue;
            if (enemy != null)
                enemy.TakeDamage(_damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _radiusExplosion);
    }
}