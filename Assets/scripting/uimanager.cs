using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uimanager : MonoBehaviour
{
    [SerializeField]
    private Text emtiaz_matn;
    [SerializeField]
    private Text bakht;
    [SerializeField]
    private Text dobare;

    [SerializeField]
    private Sprite[] joons ;
    [SerializeField]
    private Image joon_ha;

    // Start is called before the first frame update
    void Start()
    {
        
        emtiaz_matn.text = "emtiaz: " + 0 ;
        bakht.gameObject.SetActive(false);
        dobare.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void emtiaz_neshan(int emtiaz)
    {
       emtiaz_matn.text = "emtiaz: " + emtiaz ;
    }

    public void berozresani_joons(int andis)
    {
        joon_ha.sprite = joons[andis] ;
    }

    public void bakhti()
    {
        GameObject.Find("rais").GetComponent<rais>().bazi_tamom_shod();
        bakht.gameObject.SetActive(true);
        StartCoroutine(flicker());
        dobare.gameObject.SetActive(true);
    }

    IEnumerator flicker()
    {
        while(true)
        {
        bakht.text = "bakhti";
        yield return new WaitForSeconds(0.5f);
        bakht.text = "";
        yield return new WaitForSeconds(0.5f);
        }
    }

}
