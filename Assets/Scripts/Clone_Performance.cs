using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Performance : MonoBehaviour
{
    // Start is called before the first frame update
    int thisnum;
    int subject=0;
    int pattern;
    float stan;
    void Start()
    {
        thisnum= GameObject.Find("PerformanceLocation").GetComponent<Main_Performance>().num++;
        subject= GameObject.Find("GameManager").GetComponent<GM1>().order[thisnum];

        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Performances/"+subject) as Sprite;
        Debug.Log(thisnum);
        Debug.Log(subject);
        pattern=Random.Range(1,2);
        stan=GameObject.Find("GameManager").GetComponent<GM1>().speed_Background;
        switch(pattern)
        {
            case 1:
                this.transform.Translate(0,Random.Range(1,6)-3,0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(pattern)
        {
            case 1:
                this.transform.Translate(-1 * stan * Time.deltaTime*1.5f,0,0);
                break;
        }
        Debug.Log(this.transform.position.x);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameObject.Find("GameManager").GetComponent<GM1>().scores[subject] += Mathf.Lerp(0, 1, (this.transform.position.x+9)/6);
            Invoke("Thistroy", 0.03f);
        }
    }
    void Thistroy()
    {
        Destroy(gameObject);
    }
}
