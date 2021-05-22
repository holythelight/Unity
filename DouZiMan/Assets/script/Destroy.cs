using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
       void DestoryGame()
    {
        Destroy(gameObject);
    }
    void DestoryChildGame()
    {
        //if(transform.Find().gameObject.activeSelf == true)
        //{
        //    transform.Find().gameObject.SetActive(false);
        //}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
