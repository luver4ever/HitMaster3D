using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public UnityAction<Ray> Shooted;

    private void Update()
    {
        var positionToHit = _camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));


        if (Input.GetMouseButtonDown(0))
            Shooted?.Invoke(positionToHit);
    }



}
