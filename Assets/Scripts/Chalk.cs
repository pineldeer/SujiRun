using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chalk : MonoBehaviour
{
    // Start is called before the first frame update
    Color alpha;
    Color L_alpha;
    Color P_alpha;
    public GameObject Light;
    public GameObject Power;
    public GameObject Range;
    GameObject target;
    float _time=0;
    float angle;
    void Start()
    {
        alpha = this.GetComponent<SpriteRenderer>().color;
        L_alpha = Light.GetComponent<SpriteRenderer>().color;
        P_alpha = Power.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Summon_chalk()
    {
        Range.gameObject.tag = "Unbreakable";
        Range.transform.Translate(100,0,0);
        alpha.a = 0;
        L_alpha.a = 0;
        P_alpha.a = 0;
        this.transform.position=new Vector3(5.5f,-0.75f,-7);
        
        this.GetComponent<SpriteRenderer>().color = alpha;
        Light.GetComponent<SpriteRenderer>().color = L_alpha;
        Power.GetComponent<SpriteRenderer>().color = P_alpha;
        StartCoroutine(Turning());
    }
    public void Chalktroy()
    {
        Range.gameObject.tag = "Unbreakable";
        this.transform.Translate(0,100,0);
    }
    IEnumerator Turning()
    {
        _time=Time.deltaTime*0;
        Light.transform.localScale = new Vector3(30, 2, 1);
        while (_time<0.5f)
        {
            _time+=Time.deltaTime;
            alpha.a = Mathf.Lerp(0, 1, _time*2);
            //L_alpha.a = Mathf.Lerp(-0.5f, 0.5f, _time);
            P_alpha.a = Mathf.Lerp(0f, 0.5f, _time * 2);
            this.GetComponent<SpriteRenderer>().color = alpha;
            //Light.GetComponent<SpriteRenderer>().color = L_alpha;
            Power.GetComponent<SpriteRenderer>().color = P_alpha;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 1080, _time * 2));
            //Light.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 720, _time));
            Power.transform.localScale=new Vector3(Mathf.Lerp(5, 0, _time * 2), Mathf.Lerp(5, 0, _time * 2), 1);
            yield return null;
        }
        
        while (_time < 1f)
        {
            _time += Time.deltaTime;
            yield return null;
        }
        L_alpha.a =0.5f;
        Light.GetComponent<SpriteRenderer>().color = L_alpha;
        while (_time < 2f)
        {
            _time += Time.deltaTime;
            Transform target = GameObject.Find("Student").GetComponent<Transform>();
            Vector3 dir = target.position - this.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle-90f* tr.localScale.x+90f, Vector3.forward);
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.);
            //Debug.Log(angle);
            //transform.rotation = Quaternion.AngleAxis(45, Vector3.forward);
            this.transform.rotation = Quaternion.Euler(0, 0, angle);
            yield return null;
        }
        while (_time <2.5f)
        {
            _time += Time.deltaTime;
            yield return null;
        }
        L_alpha.a = 1;
        alpha.a=0;
        Light.GetComponent<SpriteRenderer>().color = L_alpha;
        this.GetComponent<SpriteRenderer>().color = alpha;
        Range.gameObject.tag = "Obstacle";
        Range.transform.position=new Vector3(0,0,0);
        while (_time < 3f)
        {
            Light.transform.localScale = new Vector3(30, Mathf.Lerp(1, 10, _time*2-5f), 1);
            L_alpha.a = Mathf.Lerp(1, 0f, _time * 2 - 5f);
            Light.GetComponent<SpriteRenderer>().color = L_alpha;
            _time += Time.deltaTime;
            yield return null;
        }
        Range.gameObject.tag = "Unbreakable";



    }
}
