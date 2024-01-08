using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{   [SerializeField]
    private float soraat = 8f ;

    // Update is called once per frame
    void Update()
    {
        move();
    }


    void move()
    {
        transform.Translate(Vector3.up * soraat * Time.deltaTime);

        if (transform.position.y >= 14f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
