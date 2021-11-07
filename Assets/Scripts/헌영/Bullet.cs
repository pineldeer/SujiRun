using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float leftMax = -6.0f;
    float rightMax = 6.5f;
    float currentPosition;
    float direction = 2.0f;

    public GameObject prefab;
    void Start(){
        currentPosition = transform.position.x;
        for (int i = 0; i < 10; i++) {
            Instantiate(prefab, new Vector3(transform.position.x + 2f * i,
                                            transform.position.y,
                                            transform.position.z), Quaternion.identity);

        
        
        }
    }
    void Update(){
        currentPosition += Time.deltaTime * direction;
        if (currentPosition >= rightMax)
        {
            direction *= -1;
            currentPosition = rightMax;

        }
        else if (currentPosition <= leftMax)
        {
            direction *= -1;
            currentPosition = leftMax;
        }
        transform.position = new Vector3(currentPosition,0, 0);
    }

   
}
