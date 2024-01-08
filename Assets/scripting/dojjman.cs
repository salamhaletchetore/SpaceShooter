using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dojjman : MonoBehaviour
{   
    [SerializeField]
    private float soraat = 5 ;
    [SerializeField]
    private AudioClip enfejar;

    private AudioSource makhzan_seda;

    private Animator dojjman_shekan;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x , 11f ,0);
        dojjman_shekan = gameObject.GetComponent<Animator>();
        makhzan_seda = GetComponent<AudioSource>();
        makhzan_seda.clip = enfejar;
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        balabiardojjman();
    }

    private void movement()
    {
        transform.Translate(Vector3.up * -1 * soraat * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D avazi)
    {
        if (avazi.tag == "cuba")
        {
            dojjman_shekan.SetTrigger("barkhord");
            soraat = 1f;
            Destroy(GetComponent<Collider2D>(),1f);
            Destroy(gameObject , 2.3f);
            avazi.transform.GetComponent<mahshid>().joonkamkon();
            makhzan_seda.Play();
        }

        if (avazi.tag == "tiro")
        {
            GameObject.Find("mahshid").GetComponent<mahshid>().name_aumal();
            dojjman_shekan.SetTrigger("barkhord");
            soraat = 1f ;
            Destroy(GetComponent<Collider2D>(),1f);
            Destroy(gameObject , 2.3f);
            Destroy(avazi.gameObject);
            makhzan_seda.Play();
            
        }

        if (avazi.tag == "shahab")
        {
           Destroy(avazi.gameObject);
           dojjman_shekan.SetTrigger("barkhord");
           soraat = 1f;
           Destroy(GetComponent<Collider2D>(),1f);
           Destroy(gameObject , 2.3f);
        }

        
    }

    void balabiardojjman()
    {
        if (transform.position.y <= -2.5f)
        {
            float rand = Random.Range(-8f , 8f);
            transform.position = new Vector3 (rand , 11f , 0);
        }

    }


}
