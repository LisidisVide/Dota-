using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [Header("CastlePlayer")]
    [SerializeField] private DataStructure _dataCastlePlayer;
    [SerializeField] private DataGameInfo _gameInfoPlayer;
    [SerializeField] private Castle _castlePlayer;

    [Header("StructPlayer")]
    [SerializeField] private DataStructure _dataStructurePlayer;
    [SerializeField] private List<Barracks> _barracksPlayer;



    [Header("CastleAi")]
    [SerializeField] private DataStructure _dataCastleAi;
    [SerializeField] private DataGameInfo _gameInfoAi;
    [SerializeField] private Castle _castleAi;

    [Header("StructAi")]
    [SerializeField] private DataStructure _dataStructureAi;
    [SerializeField] private List<Barracks> _barracksAi;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        InitializePlayer();
        InitializeAi();
    }

    private void InitializePlayer()
    {
        _castlePlayer.InitializeCastle(_dataCastlePlayer, _gameInfoPlayer, _barracksPlayer, _dataStructurePlayer);
    }

    private void InitializeAi()
    {
        _castleAi.InitializeCastle(_dataCastleAi, _gameInfoAi, _barracksAi, _dataStructureAi);
    }
}
