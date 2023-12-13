using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private bool _isEnemyCell;
    public uint numberLine;

    private void OnMouseDown()
    {
        if (!_isEnemyCell)
            Spawner.instance.Spawn(transform.position, numberLine);
    }
}
