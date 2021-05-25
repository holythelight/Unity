using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10;
    public PlayerControl playCrt;
    private AudioSource ac;
    private Animator player;
    // Start is called before the first frame update
    void Start()
    {
        playCrt = transform.root.GetComponent<PlayerControl>();
        ac = GetComponent<AudioSource>();
        player = transform.root.gameObject.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.Mouse0)) { }二选一获取按键
        if (Input.GetButtonDown("Fire1")) {
            ac.Play();
            player.Play("Shoot");
            Vector3 direction = new Vector3(0, 0, 0);
            if (playCrt.isFaceRight) {
                Rigidbody2D RocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                RocketInstance.velocity = new Vector2(fSpeed, 0);//向右不变向
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
