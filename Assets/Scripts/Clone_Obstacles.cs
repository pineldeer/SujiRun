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
        //kind =Random.Range(1,3);
        //Debug.Log(kind);
        /*
        switch (kind)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Phone") as Sprite;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Mic") as Sprite;
                this.transform.Translate(0,3,0);
                break;
            default:
                break;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-1 * speed_standard * Time.deltaTime, 0, 0);
        /*
        switch (kind)
        {
            case 1:
                this.transform.Translate(-1*speed_standard*Time.deltaTime,0,0);
                break;
            case 2:
                this.transform.Translate(-1 * speed_standard * Time.deltaTime, 0, 0);
                break;
            default:
                break;
        }*/
        if(this.transform.position.x<-10) Destroy(gameObject);
    }
}
