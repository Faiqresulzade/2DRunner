using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInstantiate : MonoBehaviour
{

    [SerializeField] private GameObject Rock;
    public List<GameObject> _rocksActive;
    public List<GameObject> _rocksPassive;
    // private GameObject InstantiateCoin;
    private void Awake()
    {
        _rocksPassive = new List<GameObject>();
    }
    void Start()
    {
        InstantiateRock();
        StartCoroutine(nameof(CoinSpawn));
    }

    private void InstantiateRock()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject InstantiateCoin = Instantiate(Rock, transform.position, Quaternion.identity);
            _rocksPassive.Add(InstantiateCoin);
            InstantiateCoin.SetActive(false);
        }
    }

    IEnumerator CoinSpawn()
    {
        while (true)
        {
            if (_rocksPassive.Count == 0)
            {
                for (int i = 0; i < _rocksActive.Count; i++)
                {
                    _rocksPassive.Add(_rocksActive[i]);
                    _rocksPassive[i].SetActive(false);
                    Destroy(_rocksPassive[i].GetComponent<MoveInstantiateObjects>());
                    _rocksActive.Remove(_rocksActive[i]);
                }
                //InstantiateCoin();
            }
            for (int i = 0; i < _rocksPassive.Count; i++)
            {
                yield return new WaitForSeconds(9f);
                _rocksPassive[i].SetActive(true);
                _rocksPassive[i].transform.position = new Vector3(15, -5f);
                _rocksPassive[i].AddComponent<MoveInstantiateObjects>();
                _rocksActive.Add(_rocksPassive[i]);
                _rocksPassive.Remove(_rocksPassive[i]);
            }
        }
    }
}
