using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreamFollow : MonoBehaviour
{
    public Transform playerTran;
    public float MaxDistanceX = 2;
    public float MaxDistanceY = 2;
    public float speedX = 3;
    public float speedY = 3;
    public Vector2 maxXY;
    public Vector2 minXY;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;

    }
    bool NeedMoveX()

    {   //x方向是否需要移动摄像机
        return Mathf.Abs(transform.position.x
                - playerTran.position.x) > MaxDistanceX;
    }
    bool NeedMoveY()
    {   //Y方向是否需要移动摄像机
        return Mathf.Abs(transform.position.y
                - playerTran.position.y) > MaxDistanceY;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        TrackPlayer();
    }
    private void TrackPlayer()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (NeedMoveX())
        {
            newX = Mathf.Lerp(transform.position.x, playerTran.position.x, speedX * Time.deltaTime);
        }
        if (NeedMoveY()) {
            newY = Mathf.Lerp(transform.position.y, playerTran.position.y, speedY * Time.deltaTime);
        }
            
        //将新摄像机位置固定在合法范围内
        newX = Mathf.Clamp(newX,minXY.x, maxXY.x);
        newY = Mathf.Clamp(newY, minXY.y,maxXY.y);
        transform.position = new Vector3(newX, newY,
                    transform.position.z);

    }
}
