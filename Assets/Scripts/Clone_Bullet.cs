using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float speed=20.0f;
    float x;
    float y;
    float z;

    void Start()
    {
        x=this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        x+=Time.deltaTime*speed;
        this.transform.position=new Vector3(x,y,z);
        if(this.transform.position.x>10) Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Performance"))
        {
            //GameObject.Find("GameManager").GetComponent<GM1>().MHP_Change(-1);
            //GameObject.Find("GameManager").GetComponent<GM1>().MHP_Display();
            //Debug.Log("장애물 맞음");
            //invinTime = 0;
            Invoke("Thistroy",0.03f);
        }
        if (collision.CompareTag("Enemy"))
        {
            //GameObject.Find("GameManager").GetComponent<GM1>().MHP_Change(-1);
            //GameObject.Find("GameManager").GetComponent<GM1>().MHP_Display();
            //Debug.Log("장애물 맞음");
            //invinTime = 0;
            Invoke("Thistroy", 0.03f);
        }
    }
    
    void Thistroy()
    {
        Destroy(gameObject);
    }
}
