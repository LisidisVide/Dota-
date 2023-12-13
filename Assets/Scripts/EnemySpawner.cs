using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _cooldown;

    [SerializeField]
    private List<GameObject> _heroes;
    [SerializeField]
    private List<GameObject> _cells;
    private float duration;

    private void Awake()
    {
        duration = 5;
    }

    private void Update()
    {
        if (duration == 0)
        {
            GameObject currentCell = _cells[Random.Range(0, _cells.Count)];
            Spawn(currentCell.transform.position, currentCell.GetComponent<Cell>().numberLine);
            duration = _cooldown + Random.Range(-1f, 1f);
        }
        else
        {
            duration -= Time.deltaTime;
            if (duration < 0)
                duration = 0;
        }
    }

    public void Spawn(Vector2 cellPosition, uint line)
    {
        Instantiate(_heroes[Random.Range(0, _heroes.Count)], cellPosition, Quaternion.identity).GetComponent<Hero>().Initialize(true, line);
    }
}
