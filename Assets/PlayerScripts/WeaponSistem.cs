using System.Security.Cryptography;
using UnityEngine;

public class WeaponSistem : MonoBehaviour
{
    Vector2 mousePosition;
    Vector2 gunDirection;

    public float angle;

    [SerializeField] private SpriteRenderer srGun;

    [SerializeField] float attackSpeed;
    bool canFire = true;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject fire;

    void Start()
    {
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gunDirection = mousePosition - new Vector2(transform.position.x, transform.position.y);
        angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg - 0f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void FixedUpdate()
    {
    }
}
