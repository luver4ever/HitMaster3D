using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Transform _lookPoint;
    [SerializeField] private StartGameButton _startGameButton;

    private bool _cameraSetted;
    private void OnEnable()
    {
        _startGameButton.GameStarted += OnGameStart;
        _cameraSetted = false;
    }
    private void OnDisable()
    {
        _startGameButton.GameStarted -= OnGameStart;
    }

    private void OnGameStart()
    {
        StartCoroutine(MoveCameraToViewPoint());
    }

    private IEnumerator MoveCameraToViewPoint()
    {
        var pathTime = 2f;
        var elapsedTime = 0f;
        while(elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(transform.position, _lookPoint.position + _positionOffset, elapsedTime);
            elapsedTime += Time.deltaTime / pathTime;

            transform.LookAt(_lookPoint.position);

            yield return null;
        }
        _cameraSetted = true;
    }
    private void Update()
    {
        if(_cameraSetted == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _lookPoint.position + _positionOffset, 10f * Time.deltaTime);
            transform.LookAt(_lookPoint.position);
        }
    }
}
