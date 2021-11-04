using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{
    float upMax = 5.0f;
    float downMax = -5.0f;
    float currentPosition;
    float direction = 4.0f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += Time.deltaTime * direction;
        if (currentPosition >= upMax)
        {
            direction *= -1;
            currentPosition = upMax;

        }
        else if (currentPosition <= downMax)
        {
            direction *= -1;
            currentPosition = downMax;
        }
        transform.position = new Vector3(6, currentPosition, 0);
        Instantiate(prefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
