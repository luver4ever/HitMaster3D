using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.enabled = false;
    }
    private void OnEnable()
    {
        _playerInput.Shooted += OnPlayerShoot;
    }
    private void OnDisable()
    {
        _playerInput.Shooted -= OnPlayerShoot;
    }

    private void OnPlayerShoot(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hit);

        transform.LookAt(hit.transform);

        _weapon.Shoot();
    }

}
