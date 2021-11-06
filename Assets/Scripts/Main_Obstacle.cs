using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    void Start()
    {
        Summon_Obstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Summon_Obstacle()
    {
        int select=Random.Range(1,4);
        switch(select)
        {
            case 1:
                Instantiate(prefab1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
                break;
            case 2:
                Instantiate(prefab2, new Vector3(transform.position.x, transform.position.y+4, transform.position.z), Quaternion.identity, transform);
                break;
            case 3:
                Instantiate(prefab3, new Vector3(transform.position.x, transform.position.y-0.75f, transform.position.z-1), Quaternion.identity, transform);
                Instantiate(prefab3, new Vector3(transform.position.x+1, transform.position.y-0.75f, transform.position.z), Quaternion.identity, transform);
                break;
            default:
                break;
        }
        Invoke("Summon_Obstacle", Random.Range(1,4 ));
        
    }
}
