using System.Collections;
using UnityEngine;

public class MoveInstantiateObjects : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position -=new  Vector3(10f, 0)*Time.deltaTime;
    }
}
