using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    // test prefab�� ������ ��ġ
    public GameObject location;
    // VR UI test�� prefab
    public GameObject cube;
    
    //public GameObject touchScreen;
    private TouchScreen touchScreen;


    // �÷��̾� �Է��� �˷��ִ� ������Ʈ
    private PlayerInput playerInput;


    // 20210812_KDH
    // udp client socket
    //public Transform ServerManager;
    private UdpSocket udpSoc;

    // 20210903_KDH
    // magic casting Ȯ�ο� bool ����
    public bool isReadytoCast_Magic = false;


    //���� �������� �����Ǵ� ���
    //public GameObject magicPrefabPos;

    //���� ������
    public GameObject[] magicPrefabs;

    //������ �߻�� ��ġ
    public Transform magicPosition;

    void Start()
    {
        //����� ������Ʈ�� ���� ��������
        playerInput = GameObject.Find("VrSetting").GetComponent<PlayerInput>();

        // 20210812_KDH udpsocket ������Ʈ ������
        //udpSoc = GameObject.Find("VrSetting").GetComponent<UdpSocket>();

        touchScreen = GameObject.Find("TouchScreenManager").GetComponent<TouchScreen>();
    }

    //���� �ֱ⿡ ���� �����
    void Update()
    {
        // 20210812 KDH �� ���۽� ���� �߻� ����
        /*
        if (udpSoc.isreceivedData)
        {
            
            if(udpSoc.curMagicStr == "magicCasting")
            {
                Debug.Log("== Ready To Cast Magic ==");
                isReadytoCast_Magic = true;
            }

            if (udpSoc.curMagicStr == "fireball" && isReadytoCast_Magic)
            {
                isReadytoCast_Magic = false;
                Debug.Log("==== fireball ====");
                playerInput.SetChangeCharacterState(1);
                FireMagic();
            }   
            else if(udpSoc.curMagicStr == "thunderStorm" && isReadytoCast_Magic)
            {
                isReadytoCast_Magic = false;
                Debug.Log("!!! thunderstorm !!!");
                playerInput.SetChangeCharacterState(2);
                FireMagic();
            }
            else if(udpSoc.curMagicStr == "ignition" && isReadytoCast_Magic)
            {
                isReadytoCast_Magic = false;
                Debug.Log("*** ignition ***");
                playerInput.SetChangeCharacterState(3);
                FireMagic();
            }
        */

        if (touchScreen.isReceivedData_magic)
        {
            /*
            if (touchScreen.magicStr == "magicCasting")
            {
                Debug.Log("== Ready To Cast Magic ==");
                isReadytoCast_Magic = true;
            }
            */
            isReadytoCast_Magic = true;

            if (touchScreen.magicStr == "fireball" && isReadytoCast_Magic)
            {
                isReadytoCast_Magic = false;
                Debug.Log("==== fireball ====");
                playerInput.SetChangeCharacterState(1);
                FireMagic();
            }
            else if (touchScreen.magicStr == "thunderStorm" && isReadytoCast_Magic)
            {
                isReadytoCast_Magic = false;
                Debug.Log("!!! thunderstorm !!!");
                playerInput.SetChangeCharacterState(2);
                FireMagic();
            }
            else if (touchScreen.magicStr == "ignition" && isReadytoCast_Magic)
            {
                isReadytoCast_Magic = false;
                Debug.Log("*** ignition ***");
                playerInput.SetChangeCharacterState(3);
                FireMagic();
            }

            /*
            if (udpSoc.curMagicStr == "fireball")
            {
                Instantiate(cube, location.transform.position, new Quaternion(), gameObject.transform);
                //isReadytoCast_Magic = false;
                Debug.Log("==== fireball ====");
                playerInput.SetChangeCharacterState(1);
                FireMagic();
            }
            else if (udpSoc.curMagicStr == "thunderStorm")
            {
                Instantiate(cube, location.transform.position, new Quaternion(), gameObject.transform);
                //isReadytoCast_Magic = false;
                Debug.Log("!!! thunderstorm !!!");
                playerInput.SetChangeCharacterState(2);
                FireMagic();
            }
            else if (udpSoc.curMagicStr == "ignition")
            {
                Instantiate(cube, location.transform.position, new Quaternion(), gameObject.transform);
                //isReadytoCast_Magic = false;
                Debug.Log("*** ignition ***");
                playerInput.SetChangeCharacterState(3);
                FireMagic();
            }
            */
        }

        //udpSoc.isreceivedData = false;

        // ���콺 input���� fireMagic ���� true�� �Ǹ� fireMagic �Լ� ���� 
        /* vr setting���� ��� ��
        if (playerInput.fireMagic == true)
        {
            FireMagic();
        }
        */
    }

    // ���� �߻� �Լ�
    void FireMagic()
    {
        if (playerInput.changeCharacterState == 0)
        { } //do nothing
        else if (playerInput.changeCharacterState == 1)
        {
            //Instantiate(cube, location.transform.position, new Quaternion(), gameObject.transform);
            // magic - fireball
            Instantiate(magicPrefabs[0], magicPosition.position, magicPosition.rotation);
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }
        else if (playerInput.changeCharacterState == 2)
        {
            //Instantiate(cube, location.transform.position, new Quaternion(), gameObject.transform);
            // magic - thunderstorm
            Instantiate(magicPrefabs[1], magicPosition.position, magicPosition.rotation); 
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }
        else if (playerInput.changeCharacterState == 3)
        {
            //Instantiate(cube, location.transform.position, new Quaternion(), gameObject.transform);
            // magic - ignition
            Instantiate(magicPrefabs[2], magicPosition.position, magicPosition.rotation);
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }

    }
}
