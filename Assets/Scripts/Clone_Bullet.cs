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
    float _time;
    Object[] sprites ;//= Resources.LoadAll("baseBallBoyWooden");
    //sprRen.sprite = sprites[2] as Sprite;



    void Start()
    {
        x=this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
        
        sprites = Resources.LoadAll("explosion");
        //this.GetComponent<SpriteRenderer>().sprite = sprites[1] as Sprite;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.tag != "Unbreakable") x +=Time.deltaTime*speed;
        this.transform.position=new Vector3(x,y,z);
        if(this.transform.position.x>10) Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.tag == "Unbreakable") return;
        if (collision.CompareTag("Performance"))
        {
            //this.gameObject.tag = "Unbreakable";
            
            Invoke("Thistroy",0.03f);
        }
        if (collision.CompareTag("Enemy"))
        {
            //this.gameObject.tag = "Unbreakable";
            Invoke("Thistroy", 0.03f);
        }
    }
    
    void Thistroy()
    {
        this.gameObject.tag = "Unbreakable";
        
        Debug.Log("폭발");

        StartCoroutine(Explode());
        CancelInvoke("Thistroy");
        //this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("explosion_" + subject) as Sprite;
        //Destroy(gameObject);
    }
    IEnumerator Explode()
    {
        _time = Time.deltaTime * 0;
        //this.transform.localScale = new Vector3(30, 2, 1);
        Debug.Log("퍽발");
        this.transform.localScale = new Vector3(5, 5, 1);
        while (_time < 0.4f)
        {
            _time += Time.deltaTime;
            Debug.Log(_time);
            this.GetComponent<SpriteRenderer>().sprite = sprites[(int)Mathf.Lerp(0,23,_time*2.55f)] as Sprite;
            yield return null;
        }//Assets/Resources/explosion.png
        Debug.Log("푹발");
        Destroy(gameObject);



    }
}
