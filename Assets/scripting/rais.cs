using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rais : MonoBehaviour
{
    
    private bool tamom_shode = false ;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && tamom_shode == true)
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public void bazi_tamom_shod()
    {
        tamom_shode = true;
    }
}
