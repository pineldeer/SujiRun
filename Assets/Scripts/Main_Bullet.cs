using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewShoot(float x, float y,float z)
    {
        this.transform.position=new Vector3(x,y,z);
        Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
