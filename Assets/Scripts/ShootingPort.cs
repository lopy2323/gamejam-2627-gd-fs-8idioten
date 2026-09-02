using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class ShootingPort : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot(projectilePrefab);
        }
    }
    public void Shoot(GameObject Projectile)
    {
        Instantiate(Projectile, transform.position, transform.rotation);
    }











}
