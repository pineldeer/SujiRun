using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject teacher;
    float _time=0f;
    //float F_Time=1f;
    void Start()
    {
        Invoke("Emergence",5.0f);
        this.gameObject.tag = "Unbreakable";
    }

    // Update is called once per frame
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(this.gameObject.tag=="Unbreakable") return;
        if (collision.CompareTag("Bullet"))
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
        //Destroy(gameObject);
        this.gameObject.tag = "Unbreakable";
        this.transform.position = new Vector3(10.5f, -1.5f, -7);
        Invoke("Emergence", 10.0f);

    }

    /*
    public void FadeIn()
    {
        Panel.gameObject.SetActive(true);
        StartCoroutine(FadeInFlow());
    }
    IEnumerator Coming()
    {
        Color alpha = Panel.color;
        //Debug.Log(alpha);
        //Debug.Log("페이드인");

        while (alpha.a < 1f)
        {
            //Debug.Log("페이드인인");
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            
        }

        Invoke("Star", 1f);
        yield return null;
    }*/
}
