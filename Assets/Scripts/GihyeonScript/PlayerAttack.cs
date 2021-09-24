using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    // test prefab이 생성될 위치
    public GameObject location;
    // VR UI test용 prefab
    public GameObject cube;
    
    //public GameObject touchScreen;
    private TouchScreen touchScreen;


    // 플레이어 입력을 알려주는 컴포넌트
    private PlayerInput playerInput;


    // 20210812_KDH
    // udp client socket
    //public Transform ServerManager;
    private UdpSocket udpSoc;

    // 20210903_KDH
    // magic casting 확인용 bool 변수
    public bool isReadytoCast_Magic = false;


    //마법 프리팹이 생성되는 장소
    //public GameObject magicPrefabPos;

    //마법 프리팹
    public GameObject[] magicPrefabs;

    //마법이 발사될 위치
    public Transform magicPosition;

    void Start()
    {
        //사용할 컴포넌트의 참조 가져오기
        playerInput = GameObject.Find("VrSetting").GetComponent<PlayerInput>();

        // 20210812_KDH udpsocket 컴포넌트 가져옴
        //udpSoc = GameObject.Find("VrSetting").GetComponent<UdpSocket>();

        touchScreen = GameObject.Find("TouchScreenManager").GetComponent<TouchScreen>();
    }

    //물리 주기에 맞춰 실행됨
    void Update()
    {
        // 20210812 KDH 손 동작시 마법 발사 구현
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

        // 마우스 input으로 fireMagic 값이 true가 되면 fireMagic 함수 실행 
        /* vr setting에서 잠시 뺌
        if (playerInput.fireMagic == true)
        {
            FireMagic();
        }
        */
    }

    // 마법 발사 함수
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
