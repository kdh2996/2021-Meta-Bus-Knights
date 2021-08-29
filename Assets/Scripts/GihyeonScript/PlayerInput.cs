using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//����� �Է� ���� , ������ �Է°��� �ٸ� ������Ʈ�� ����� �� �ְ� ����
public class PlayerInput : MonoBehaviour
{
    //ī�޶� ����
    public float rotateSpeed = 200;
    float mouseAngleX;
    float mouseAngleY;

    //�� �Ҵ��� ���ο����� �����ϵ��� getter/setter ����
    public bool fireMagic { get; private set; }
    public int changeCharacterState { get; private set; }

    
    // ���� �߻�� ĳ���� ���� ���� �Լ� �ʱ�ȭ
    void Start()
    {
        fireMagic = false;
        // 0:�⺻, 1: fireball, 2 : thunderstorm, 3 : ignition
        changeCharacterState = 0;
    }

   
    // �� �����Ӹ��� �Է� üũ
    void Update()
    {
        //ī�޶� ����
        // ���콺 x,y���� ������ ���� , �¿� : y�� ȸ��, ���Ʒ� : x�� ȸ��
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        // P = P0 + vt
        mouseAngleX += x * rotateSpeed * Time.deltaTime; // ���콺 x���� ����
        mouseAngleY += y * rotateSpeed * Time.deltaTime; // ���콺 y���� ����

        /*
        if (mouseAngleY >= 90)
        {
            mouseAngleY = 90;
        }
        else if (mouseAngleY <= -90)
        {
            mouseAngleY = -90;
        }*/
        //mouseAngleY�� �ּ�,�ִ� ����
        mouseAngleY = Mathf.Clamp(mouseAngleY, -90, 90);

        //�ȼ��� ��ȣ�� ���Ʒ� �ݴ��̹Ƿ�, mouseAngleY�� -1�� ���ؼ� �ݴ�� �����.
        transform.eulerAngles = new Vector3(-mouseAngleY, mouseAngleX, 0);

        fireMagic = Input.GetMouseButtonDown(0);

        if (Input.GetMouseButtonDown(1))
        {
            changeCharacterState++;
            changeCharacterState = changeCharacterState % 4;
        }
    }

    // 20210812 changeCharacterState setter 
    public void setChangeCharacterState(int val)
    {
        changeCharacterState = val;
    }
}
