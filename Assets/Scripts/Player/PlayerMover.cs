using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Level _level;
 
    private NavMeshAgent _playerAgent;
    private PlayerPoint[] _pointsToMove;
    private PlayerPoint _currentPoint;
    private int _pointIndex = 0;

    public int PointIndex => _pointIndex;
    public int FinishPlatformIndex => _pointsToMove.Length - 1;

    public UnityAction<Vector3> PointUpdated;
    private void Start()
    {
        _playerAgent = GetComponent<NavMeshAgent>();

        _pointsToMove = _level.PlayerPoints;
    }
    public void MovePlayer()
    {
        if (_pointIndex <= FinishPlatformIndex)
            _pointIndex++;

        if (_pointIndex < _pointsToMove.Length)
        {
            _currentPoint = _pointsToMove[_pointIndex];

            PointUpdated?.Invoke(_currentPoint.transform.position);

            _playerAgent.SetDestination(_currentPoint.transform.position);
        }
    }


}
