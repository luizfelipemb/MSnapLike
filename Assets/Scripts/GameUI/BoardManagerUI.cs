using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerUI : MonoBehaviour
{
    [SerializeField] private LocationUI location0;
    [SerializeField] private LocationUI location1;
    [SerializeField] private LocationUI location2;
    [SerializeField] private LocationUI location3;
    [SerializeField] private LocationUI location4;
    [SerializeField] private LocationUI location5;

    private void Awake()
    {
        GameManager.BoardChanged.AddListener(GameManager_BoardChanged);
    }
    private void GameManager_BoardChanged(Board board)
    {
        location0?.UpdateLocation(board.p1Side[0]);
        location1?.UpdateLocation(board.p1Side[1]);
        location2?.UpdateLocation(board.p1Side[2]);
        location3?.UpdateLocation(board.p2Side[0]);
        location4?.UpdateLocation(board.p2Side[1]);
        location5?.UpdateLocation(board.p2Side[2]);
    }
}
