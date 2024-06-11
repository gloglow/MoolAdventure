using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefabs;
    [SerializeField] private int[] monsterCnts;

    public BoxCollider spawnRange;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        for(int i = 0; i < monsterCnts.Length; i++)
        {
            for (int j = 0; j < monsterCnts[i]; j++)
            {
                Vector3 _randomRotation = new Vector3(Random.Range(0, 360), 0, Random.Range(0, 360));
                GameObject _gameObj = Instantiate(monsterPrefabs[i], GetRandomPosition(), Quaternion.Euler(_randomRotation));
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 _originPos = spawnRange.transform.position;

        float _rangeX = spawnRange.bounds.size.x;
        float _rangeZ = spawnRange.bounds.size.z;

        _rangeX = Random.Range((_rangeX / 2) * -1, _rangeX / 2);
        _rangeZ = Random.Range((_rangeZ / 2) * -1, _rangeZ / 2);

        return _originPos + new Vector3(_rangeX, 0f, _rangeZ);
    }
}
