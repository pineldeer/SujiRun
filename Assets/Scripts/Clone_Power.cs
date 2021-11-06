using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Power : MonoBehaviour
{
    // Start is called before the first frame update
    Color P_alpha;
    float _time = 0;
    void Start()
    {
        P_alpha = this.GetComponent<SpriteRenderer>().color;
        P_alpha.a = 0;
        this.GetComponent<SpriteRenderer>().color = P_alpha;
        StartCoroutine(Gathering());
    }
    IEnumerator Gathering()
    {
        _time = Time.deltaTime * 0;
        //Light.transform.localScale = new Vector3(30, 2, 1);
        while (_time < 0.5f)
        {
            _time += Time.deltaTime;
            //alpha.a = Mathf.Lerp(0, 1, _time * 2);
            //L_alpha.a = Mathf.Lerp(-0.5f, 0.5f, _time);
            P_alpha.a = Mathf.Lerp(0f, 0.5f, _time * 2);
            //this.GetComponent<SpriteRenderer>().color = alpha;
            //Light.GetComponent<SpriteRenderer>().color = L_alpha;
            this.GetComponent<SpriteRenderer>().color = P_alpha;
            //transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 1080, _time * 2));
            //Light.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 720, _time));
            this.transform.localScale = new Vector3(Mathf.Lerp(5, 0, _time * 2), Mathf.Lerp(5, 0, _time * 2), 1);
            yield return null;
        }

        
        Destroy(gameObject);



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
