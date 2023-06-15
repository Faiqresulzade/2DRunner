using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoin : MonoBehaviour
{

    [SerializeField] private GameObject Coin;
    public List<GameObject> _coinsActive;
    public List<GameObject> _coinsPassive;
    // private GameObject InstantiateCoin;
    private void Awake()
    {
        _coinsPassive = new List<GameObject>();
    }
    void Start()
    {
        InstantiateCoins();
        StartCoroutine(nameof(CoinSpawn));
    }

    private void InstantiateCoins()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject InstantiateCoin = Instantiate(Coin, transform.position, Quaternion.identity);
            _coinsPassive.Add(InstantiateCoin);
            InstantiateCoin.SetActive(false);
        }
    }

    IEnumerator CoinSpawn()
    {
        while (true)
        {
            if (_coinsPassive.Count == 0)
            {
                for (int i = 0; i < _coinsActive.Count; i++)
                {
                    _coinsPassive.Add(_coinsActive[i]);
                    _coinsPassive[i].SetActive(false);
                    Destroy(_coinsPassive[i].GetComponent<MoveInstantiateObjects>());
                    _coinsActive.Remove(_coinsActive[i]);
                }
                //InstantiateCoin();
            }
            for (int i = 0; i < _coinsPassive.Count; i++)
            {
                yield return new WaitForSeconds(5f);
                _coinsPassive[i].SetActive(true);
                _coinsPassive[i].transform.position =new  Vector3(15,-5f);
                _coinsPassive[i].AddComponent<MoveInstantiateObjects>();
                _coinsActive.Add(_coinsPassive[i]);
                _coinsPassive.Remove(_coinsPassive[i]);
            }
        }
    }
}
