using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mahshid : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private GameObject gholam ;
    [SerializeField]
    private GameObject se_tiroo_pref;
    [SerializeField]
    private GameObject nomayande_separ;
    [SerializeField]
    private int joon = 3 ;
    [SerializeField]
    private float firerate = 0.3f;
    [SerializeField]
    private GameObject takhrib_rast;
    [SerializeField]
    private GameObject takhrib_chap;
    [SerializeField]
    private AudioClip seda_tir;

    private AudioSource manbau;
    
    private float canfire = -1f;

    private oonfetne oonefetne;


    private bool hokme_se_tir = false ;
    private bool pa_ro_gaz = false;
    private bool separ_bala = false;
    private int  godrat_nou = -1;

    [SerializeField]
    private int emtiaz = 0 ;
    



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (0 , 0, 0);
        oonefetne = GameObject.Find("oonefetne").GetComponent<oonfetne>();
        manbau = GetComponent<AudioSource>();
        manbau.clip = seda_tir;
        takhrib_rast.SetActive(false);
        takhrib_chap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement();    

        tir();

    }

    void movement()
    {
        float horozontol = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        if (pa_ro_gaz == true)
        {
            speed = 10f;
        }
        
        Vector3 shapor = new Vector3 (horozontol , vertical , 0);
        transform.Translate(shapor * speed  * Time.deltaTime);


        if (transform.position.y >= 8.5f )
        {
            transform.position = new Vector3 (transform.position.x , 8.5f , 0);
        }

        else if(transform.position.y <= -2f)
        {
            transform.position = new Vector3 (transform.position.x , -2f , 0);
        }

        if (transform.position.x >= 8f)
        {
            transform.position = new Vector3(8f , transform.position.y , 0);
        }
        else if (transform.position.x <= -8f)
        {
            transform.position = new Vector3 (-8f , transform.position.y , 0);
        }

    }


    void tir()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > canfire && hokme_se_tir == false)
        {
            canfire = Time.time + firerate ;
            Instantiate(gholam , new Vector3(transform.position.x , transform.position.y + 0.5f , 0) , Quaternion.identity);
            manbau.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && hokme_se_tir == true)
        {
            Instantiate (se_tiroo_pref ,new Vector3(transform.position.x + 0.85f, transform.position.y + 1.2f , 0) , Quaternion.identity);
            manbau.Play();       
        }

        
    }

    public void joonkamkon()
    {
        if (separ_bala == false)
        {
            joon -= 1 ;
            GameObject.Find("Canvas").GetComponent<uimanager>().berozresani_joons(joon);
            if(joon == 2)
            {
                takhrib_rast.SetActive(true);
            }

            else if(joon == 1)
            {
                takhrib_chap.SetActive(true);
            }

            else if (joon == 0)
            {
                oonefetne.baybaymahshid();
                GameObject.Find("Canvas").GetComponent<uimanager>().bakhti();
                Destroy(gameObject);
                
            }
            

        }


    }

    public void hokme_se_tir_sader()
    {
        hokme_se_tir = true;
        godrat_nou = 0 ;
        StartCoroutine(etmam_hokm());
    }

    public void gazesh_ro_begir()
    {
        pa_ro_gaz = true;
        godrat_nou = 1;
        StartCoroutine(etmam_hokm());
    }

    public void separ_ro_biyar_bala()
    {
        separ_bala = true;
        nomayande_separ.SetActive(true);
        StartCoroutine(makhzan_separ_tamam());
    }

    IEnumerator etmam_hokm()
    {
        yield return new WaitForSeconds(5.0f);
        if(godrat_nou == 0)
        {
            hokme_se_tir = false;
        }

        else if (godrat_nou == 1)
        {
            pa_ro_gaz = false;
            speed = 6f;
        }
    }

    IEnumerator makhzan_separ_tamam()
    {
        yield return new WaitForSeconds(2.0f);
        separ_bala = false ;
        nomayande_separ.SetActive(false);
    }


    public void name_aumal()
    {
        emtiaz += 10 ;
        GameObject.Find("Canvas").GetComponent<uimanager>().emtiaz_neshan(emtiaz); 
    }

    

}
