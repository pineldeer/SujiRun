using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chalk : MonoBehaviour
{
    // Start is called before the first frame update
    Color alpha;
    float _time=0;

    void Start()
    {
        alpha = this.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Summon_chalk()
    {
        alpha.a = 0;
        this.transform.position=new Vector3(5.5f,-0.75f,-7);
        
        this.GetComponent<SpriteRenderer>().color = alpha;
        StartCoroutine(Turning());
    }
    IEnumerator Turning()
    {
        _time=Time.deltaTime*0;
        while(_time<1)
        {
            _time+=Time.deltaTime;
            alpha.a = Mathf.Lerp(0, 1, _time);
            this.GetComponent<SpriteRenderer>().color = alpha;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 1080, _time));
            yield return null;
        }
        


    }
}
