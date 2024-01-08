using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTransmitter : MonoBehaviour
{
    [SerializeField] private SplineComputer _playerSpline1;
    //[SerializeField] private SplineComputer _playerSpline2;
    [SerializeField] private PlayerHolder _playerHolder;

    public void UpdatePath(SplineComputer line)
    {
        _playerSpline1.SetPoints(line.GetPoints(SplineComputer.Space.Local), SplineComputer.Space.Local);
        _playerHolder.ArrangePlayers(_playerSpline1);
    }
}
