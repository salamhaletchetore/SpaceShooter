using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oonfetne : MonoBehaviour
{
    [SerializeField]
    private GameObject dojjmanpref;
    [SerializeField]
    private GameObject container;
    [SerializeField]
    private GameObject se_tiroo;
    [SerializeField]
    private GameObject soraat;
    [SerializeField]
    private GameObject godrat_list;
    [SerializeField]
    private GameObject shahab;
    [SerializeField]
    private GameObject[] anvae_godrat;
    private bool dokmeyemarg = false ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(aghmodir());
        StartCoroutine(hal_bede_1());
        StartCoroutine(shahab_sang());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator aghmodir()
    {
        while (dokmeyemarg == false)
        {
            Vector3 jayaval = new Vector3(Random.Range(-8f,8f) , 11f , 0);
            GameObject motavaled = Instantiate(dojjmanpref , jayaval , Quaternion.identity);
            motavaled.transform.parent = container.transform ;
            yield return new WaitForSeconds (2.5f);
        }
    }


    IEnumerator hal_bede_1()
    {
      while (dokmeyemarg == false)
      {
         Vector3 jaye_aval = new Vector3(Random.Range(-8f,8f) , 11f , 0);
         int random = Random.Range(0,3);
         GameObject jadid = Instantiate(anvae_godrat[random], jaye_aval , Quaternion.identity);
         jadid.transform.parent = godrat_list.transform ; 
         yield return new WaitForSeconds(Random.Range(10f,12f));  
      }
    }

    IEnumerator shahab_sang()
    {
        while(dokmeyemarg == false)
        {
            Vector3 jayeaval = new Vector3(Random.Range(-8f,8f) , 11f , 0);
            float shansi = Random.Range(5f , 15f);
            GameObject New = Instantiate(shahab,jayeaval, Quaternion.identity);
            New.transform.parent = container.transform ;
            yield return new WaitForSeconds(shansi);
        }    
    }

    public void baybaymahshid()
    {
        dokmeyemarg = true ;
    }
}
