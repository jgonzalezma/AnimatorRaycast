using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boyPrefab; //referencia al prefab, del cual quiero sacar clones
    public Transform[] pos;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBoys", time, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBoys()
    {
        int n = Random.Range(0, pos.Length);
        Instantiate(boyPrefab, pos[n].position, pos[n].rotation);
    }
}
