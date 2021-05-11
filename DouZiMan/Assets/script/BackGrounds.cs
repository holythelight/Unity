using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounds : MonoBehaviour
{
    public Transform[] backGround;
    public float fParallax = 0.4f;
    public float layerFraction = 5f;
    public float fSmooth = 0.05f;
    Transform cam;
    Vector3 previousCamPos;
    //art is called before the first frame update
    private void Awake()
    {
        cam = Camera.main.transform;
    }
    private void Start()
    {
        previousCamPos = cam.position;
    }
    // Update is called once per frame
    void Update()
    {
        float fparalaxX = (previousCamPos.x - cam.position.x) * fParallax;
        for(int i = 0; i < backGround.Length; i++)
        {
            float fNewX = backGround[i].position.x + fparalaxX * (1 + i * layerFraction);
            Vector3 newPos = new Vector3(fNewX, backGround[i].position.y, backGround[i].position.z);
            backGround[i].position = Vector3.Lerp(backGround[i].position, newPos,fSmooth * Time.deltaTime);

        }
        previousCamPos = cam.position;
    }
}
