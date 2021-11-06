using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Light : MonoBehaviour
{
    // Start is called before the first frame update
    Color L_alpha;
    float _time = 0;

    void Start()
    {
        L_alpha = this.GetComponent<SpriteRenderer>().color;
        L_alpha.a = 0.5f;
        this.GetComponent<SpriteRenderer>().color = L_alpha;
        StartCoroutine(Aiming());
    }
    IEnumerator Aiming()
    {
        _time = Time.deltaTime * 0;
        this.transform.localScale = new Vector3(30, 2, 1);
       
        while (_time < 1.5f)
        {
            _time += Time.deltaTime;
            
            yield return null;
        }
        L_alpha.a = 1;
        this.GetComponent<SpriteRenderer>().color = L_alpha;
        while (_time < 2f)
        {
            this.transform.localScale = new Vector3(30, Mathf.Lerp(1, 30, _time * 2 - 3f), 1);
            L_alpha.a = Mathf.Lerp(1, 0f, _time * 2 - 3f);
            this.GetComponent<SpriteRenderer>().color = L_alpha;
            _time += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);



    }
    // Update is called once per frame
    void Update()
    {

    }
}
