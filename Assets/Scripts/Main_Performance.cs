using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Performance : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab_Per;
    public int num;
    void Start()
    {
        num=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Summon_Per()
    {
        Instantiate(prefab_Per, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
        
    }
}
