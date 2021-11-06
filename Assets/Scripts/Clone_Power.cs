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
        while (_time < 0.5f)
        {
            _time += Time.deltaTime;
            P_alpha.a = Mathf.Lerp(0f, 0.3f, _time * 2);
            this.GetComponent<SpriteRenderer>().color = P_alpha;
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
