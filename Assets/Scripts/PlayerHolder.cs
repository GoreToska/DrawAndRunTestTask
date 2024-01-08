using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHolder : MonoBehaviour
{
    [SerializeField] private List<SplineFollower> players;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerParent;
    [SerializeField] private List<SplinePositioner> players2;
    [SerializeField] private SplineComputer spline;

    public static UnityAction<SplinePositioner> OnSplineFollowerDead;
    public static UnityAction<SplinePositioner> OnGuyPickUp;


    private void Awake()
    {
        OnSplineFollowerDead += RemovePlayer;
        OnGuyPickUp += AddNewPlayer;
    }

    public void ArrangePlayers(SplineComputer spline)
    {
        for (var i = 0; i < players2.Count; i++)
        {
            //players2[i].spline = spline;
            players2[i].SetPercent(i * (100 / players2.Count) * 0.01f);
            players2[i].RebuildImmediate();
        }

        //spline.RebuildImmediate(true, true);
    }

    private void RemovePlayer(SplinePositioner player)
    {
        players2.Remove(player);

        if (players2.Count == 0)
        {
            GameMod.OnLose();
        }
    }

    private void AddNewPlayer(SplinePositioner player)
    {
        player.spline = spline;
        players2.Add(player);
        player.Rebuild();
        player.SetPercent(player.GetPercent() + 0.1f);
        ArrangePlayers(spline);
    }
}
