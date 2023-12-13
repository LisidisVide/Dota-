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

    [SerializeField]
    private int _resourses;
    [SerializeField]
    private float _waitSecond;

    private void Awake()
    {
        instance = this;
        StartCoroutine(AddResource());
    }

    public void Spawn(Vector2 cellPosition, uint line)
    {
        if (_resourses >= _selectedHero.GetComponent<Hero>().price)
        {
            Instantiate(_selectedHero, cellPosition, Quaternion.identity).GetComponent<Hero>().Initialize(false, line);
            _resourses -= _selectedHero.GetComponent<Hero>().price;
        }
    }

    private IEnumerator AddResource()
    {
        while(true)
        {
            yield return new WaitForSeconds(_waitSecond);
            _resourses++;
        }
    }
}
