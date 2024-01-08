using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godrat_code : MonoBehaviour
{   
    [SerializeField] 
    private float soraat = 3f ;
    private Collider2D migholi ; 
    [SerializeField]
    private int halate_godrat = 0 ;
    [SerializeField]
    private AudioClip godrat_seda;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();

    }

    void movement()
    {
        transform.Translate (Vector3.down * soraat * Time.deltaTime);
        if (transform.position.y <= -4.5f )
        {
            Destroy(gameObject);
        } 
    }

    private void OnTriggerEnter2D(Collider2D migholi)
    {   


        if (migholi.tag == "cuba")
        {
            AudioSource.PlayClipAtPoint(godrat_seda , transform.position);
            if (halate_godrat == 0)
            {

                migholi.transform.GetComponent<mahshid>().hokme_se_tir_sader() ;
                Destroy(gameObject);
            }

            else if(halate_godrat == 1)
            {

                migholi.transform.GetComponent<mahshid>().gazesh_ro_begir();
                Destroy(gameObject);
            }

            else if(halate_godrat == 2)
            {

                migholi.transform.GetComponent<mahshid>().separ_ro_biyar_bala();
                Destroy(gameObject);
            }
        }


    }

}
