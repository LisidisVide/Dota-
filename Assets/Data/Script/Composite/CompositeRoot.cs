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
    [SerializeField] private List<Barrack> _barracksPlayer;

    [Header("CastleAi")]
    [SerializeField] private DataStructure _dataCastleAi;
    [SerializeField] private DataGameInfo _gameInfoAi;
    [SerializeField] private Castle _castleAi;

    [Header("StructAi")]
    [SerializeField] private DataStructure _dataStructureAi;
    [SerializeField] private List<Barrack> _barracksAi;

    [Header("Path")]
    [SerializeField] private List<Path> _path;

    [Header("View")]
    [SerializeField] private List<Heart> _hearts;
    [SerializeField] private HealPointView _healPointView;

    [Header("Units")]
    [SerializeField] private Warrior _prefabWarrior;

    [Header("Other")]
    [SerializeField] private Trash _trash;
    [SerializeField] private Barricade _prefabBaricade;
    [SerializeField] private int _numberBaricade;
    [SerializeField] private BarricadeBuilder _barricadeBuilder;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        foreach(var path in _path)
        {
            path.SearchPoint();
        }

        InitializePlayer();
        InitializeAi();
        InitializeView();
        InitializeData();
        StartGame();
    }

    private void InitializePlayer()
    {
        _castlePlayer.InitializeCastle(_dataCastlePlayer, _gameInfoPlayer, _barracksPlayer, _dataStructurePlayer, _path, _prefabWarrior, _trash);
        _barricadeBuilder.InitBuilder(_prefabBaricade, _numberBaricade);
    }

    private void InitializeAi()
    {
        _castleAi.InitializeCastle(_dataCastleAi, _gameInfoAi, _barracksAi, _dataStructureAi, _path, _prefabWarrior, _trash);
    }

    private void InitializeView()
    {
        _healPointView.Initialize(_castlePlayer, _hearts);
    }

    private void InitializeData()
    {
        _castlePlayer.InitializeEvent();
        _castleAi.SetEnemyCounter(_castlePlayer.Counter);
        _castlePlayer.SetEnemyCounter(_castleAi.Counter);
    }

    private void StartGame()
    {
        //foreach (var barrack in _barracksPlayer)
        //{
        //    barrack.SpawnUnits();
        //}

        //foreach (var barrack in _barracksAi)
        //{
        //    barrack.SpawnUnits();
        //}
        _barracksPlayer[0].SpawnUnits();
        //_barracksAi[0].SpawnUnits();
    }
}
