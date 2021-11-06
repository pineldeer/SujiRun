using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chalk : MonoBehaviour//분필의 행동을 제어하는 코드
{
    Color alpha;
    public GameObject Light;
    public GameObject Power;
    public GameObject Laser;
    GameObject target;
    float _time=0;
    float angle;
    void Start()
    {
        alpha = this.GetComponent<SpriteRenderer>().color;
        alpha.a = 0;
        this.transform.position = new Vector3(5.5f, -0.75f, -7);

        this.GetComponent<SpriteRenderer>().color = alpha;
        Instantiate(Power, transform.position, Quaternion.identity, transform);
        StartCoroutine(Turning());

    }
    IEnumerator Turning()
    {
        _time = Time.deltaTime * 0;
        while (_time < 0.5f)//0.5초간 회전
        {
            _time += Time.deltaTime;
            alpha.a = Mathf.Lerp(0, 1, _time * 2);
            this.GetComponent<SpriteRenderer>().color = alpha;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 1080, _time * 2));
            yield return null;
        }

        while (_time < 1f)//0.5초간 대기
        {
            _time += Time.deltaTime;
            yield return null;
        }
        Instantiate(Light, transform.position, Quaternion.identity, transform);

        while (_time < 2f)//1초간 플레이어를 타겟팅
        {
            _time += Time.deltaTime;
            Transform target = GameObject.Find("Student").GetComponent<Transform>();
            Vector3 dir = target.position - this.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0, 0, angle);
            yield return null;
        }

        while (_time < 2.5f)
        {
            _time += Time.deltaTime;
            yield return null;
        }
        alpha.a = 0;
        Instantiate(Laser, transform.position, Quaternion.Euler(0, 0, angle), transform);
        this.GetComponent<SpriteRenderer>().color = alpha;

        while (_time < 3f)
        {
            _time += Time.deltaTime;
            yield return null;
        }

        
        Destroy(gameObject);



    }
    
}
