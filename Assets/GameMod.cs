using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameMod : MonoBehaviour
{
    public static GameMod Instance;
    [field: SerializeField] public SplineComputer Spline { get; private set; }
    public static UnityAction OnLose;
    public static UnityAction OnWin;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

        OnLose += Lose;
        OnWin += Win;
    }

    private void Lose()
    {
        StopAll();
    }

    private void StopAll()
    {
        foreach (var sub in Spline.GetSubscribers())
        {
            if (sub.TryGetComponent<SplineFollower>(out var component))
            {
                component.followSpeed = 0;
            }
        }
    }

    private void Win()
    {
        StopAll();
    }
}
