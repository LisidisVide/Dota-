using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    [SerializeField]
    private GameObject _selectedHero;
    [SerializeField]
    private List<GameObject> _heroes;

    private void Awake()
    {
        instance = this;
    }

    public void Spawn(Vector2 cellPosition, uint line)
    {
        Instantiate(_selectedHero, cellPosition, Quaternion.identity).GetComponent<Hero>().Initialize(false, line);
    }
}
