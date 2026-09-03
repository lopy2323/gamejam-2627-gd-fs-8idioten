using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class ShootingPort : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;


    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot(projectilePrefab);
        }
        if (context.canceled)
        {

        }
    }
    private void Shoot(GameObject Projectile)
    {
        GameObject bullet = Instantiate(Projectile, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().velocity = transform.GetComponent<SpaceShipMovment>().velocity;
        bullet.GetComponent<Bullet>().originCollider =  transform.GetComponent<Collider2D>();
    }











}
