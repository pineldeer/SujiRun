using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copy : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        Destroy(gameObject, 0.7f);

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Deadline") {

            Debug.Log("ÃÑ¾ËÆÄ±«µÊ");
            Destroy(gameObject, 2);
            
        }
    }
}
