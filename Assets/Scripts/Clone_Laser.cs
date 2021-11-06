using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Laser : MonoBehaviour
{
    // Start is called before the first frame update
    Color La_alpha;
    float _time = 0;
    void Start()
    {
        StartCoroutine(Lasering());
    }
    IEnumerator Lasering()
    {
        _time = Time.deltaTime * 0;
        while (_time < 0.05f)
        {
            _time += Time.deltaTime;

            this.transform.localScale = new Vector3(30, Mathf.Lerp(0, 2, _time * 4), 1);
            yield return null;
        }
        this.gameObject.tag="Unbreakable";
        while (_time < 0.25f)
        {
            _time += Time.deltaTime;

            this.transform.localScale = new Vector3(30, Mathf.Lerp(0, 2, _time * 4), 1);
            yield return null;
        }

        while (_time < 0.5f)
        {
            _time += Time.deltaTime;
            this.transform.localScale = new Vector3(30, Mathf.Lerp(2, 0, _time * 4-1), 1);
            yield return null;
        }




    }

    
    void Update()
    {
        
    }
}
