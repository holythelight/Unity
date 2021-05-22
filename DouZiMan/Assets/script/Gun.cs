using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10;
    public PlayerControl playCrt;
    private AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        playCrt = transform.root.GetComponent<PlayerControl>();
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.Mouse0)) { }��ѡһ��ȡ����
        if (Input.GetButtonDown("Fire1")) {
            ac.Play();
            Vector3 direction = new Vector3(0, 0, 0);
            if (playCrt.isFaceRight) {
                Rigidbody2D RocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                RocketInstance.velocity = new Vector2(fSpeed, 0);//���Ҳ�����
            }
            else
            {
                direction.z = 180;
                Rigidbody2D RocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                RocketInstance.velocity = new Vector2(-fSpeed, 0);
            }

        }
        
    }
}
