using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    // Start is called before the first frame update
    float _time=0f;
    public GameObject prefab;
    GameObject inst;
    //float F_Time=1f;
    void Start()
    {
        Invoke("Emergence",5.0f);
        this.gameObject.tag = "Unbreakable";
    }

    void Update()
    {
        
    }
    void Emergence()
    {
        this.transform.position=new Vector3(10.5f,-1.5f,-7);
        StartCoroutine(Coming());
    }
    IEnumerator Coming()
    {
        _time=Time.deltaTime*0;
        while(_time<1)
        {
            _time+=Time.deltaTime;
            this.transform.position=new Vector3(10.5f-3*Mathf.Lerp(0,1,_time),-1.5f,-7);
            yield return null;
        }
        this.gameObject.tag = "Enemy";
        InvokeRepeating("Ch", 0, 3.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(this.gameObject.tag=="Unbreakable") return;
        if (collision.CompareTag("Bullet"))
        {
            Invoke("Thistroy", 0.03f);
        }
    }

    void Thistroy()
    {
        this.gameObject.tag = "Unbreakable";
        this.transform.position = new Vector3(10.5f, -1.5f, -7);
        Invoke("Emergence", 10.0f);
        CancelInvoke("Ch");
        Destroy(inst);

    }
    void Ch()
    {
        inst=Instantiate(prefab, new Vector3(0, 100, 0), Quaternion.identity, transform);
    }
}