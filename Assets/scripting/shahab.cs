using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shahab : MonoBehaviour
{
    [SerializeField]
    private float gardesh = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * gardesh * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D avazi)
    {
        if (avazi.tag == "tiro")
        {
            GameObject.Find("mahshid").GetComponent<mahshid>().name_aumal();
            GameObject.Find("mahshid").GetComponent<mahshid>().name_aumal();
            Destroy(avazi.gameObject);
            Destroy(gameObject);
        }

        if (avazi.tag == "cuba")
        {
            Destroy(gameObject);
            avazi.transform.GetComponent<mahshid>().joonkamkon();
            avazi.gameObject.GetComponent<mahshid>().joonkamkon();
        }
    }
}
