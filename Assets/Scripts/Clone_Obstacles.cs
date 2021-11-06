using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    int kind;
    float speed_standard;
    void Start()
    {
        speed_standard=GameObject.Find("GameManager").GetComponent<GM1>().speed_Background;
 
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-1 * speed_standard * Time.deltaTime, 0, 0);
        
        if(this.transform.position.x<-10) Destroy(gameObject);
    }
}
