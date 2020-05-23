using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingScript : MonoBehaviour
{
    Rigidbody m_rigidbody;

    //マウスで回転するスピード
    public float rotateSpeed = 2.0f;

    //投げる物体
    public GameObject throwimgObject;
    //ScoreManegeScriptを参照するため
    public GameObject scoreManagement;

    //前に進むスピード
    public Vector3 forwardSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_rigidbody = GetComponent<Rigidbody>();

        //進む時のスピード設定
        forwardSpeed = new Vector3(0.0f, 0.0f, 0.1f);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x <= 3.0f)
            {
                //右ボタンで右に
                transform.position += new Vector3(0.5f, 0.0f, 0.0f);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x >= -3.0f)
            {
                //左ボタンで左に
                transform.position += new Vector3(-0.5f, 0.0f, 0.0f);
            }
        }

        //常に前に進む
        transform.position += forwardSpeed;

        //マウスで回転するための関数呼び出し
        RotateCamera();

        if (Input.GetMouseButtonDown(0))
        {
            Throwingball();
        }
    }

    //マウスで視点を回転させる
    private void RotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed,Input.GetAxis("Mouse Y")*rotateSpeed,0);

        //transform.RotateAround()を使用してメインカメラを回転させる
        //左右回転
        transform.RotateAround(transform.position, Vector3.up, angle.x);
        //上下回転
        transform.RotateAround(transform.position, transform.right, -angle.y);
    }

    //ボールを投げる
    void Throwingball()
    {
        //ボールを生成
        GameObject ball = Instantiate(throwimgObject, this.transform.position,Quaternion.identity);
        //生成されたオブジェクトのコンポーネントを取得
        Rigidbody rid = ball.GetComponent<Rigidbody>();
        //ボールに力を加える
        rid.AddForce(this.transform.forward * rid.mass * 20.0f, ForceMode.Impulse);

        //生成したボールを３秒後に消す
        Destroy(ball,2.5f);

        //ボールのコスト分お金を減らす
        scoreManagement.GetComponent<ScoreManageScript>().ballcost();
    }
}