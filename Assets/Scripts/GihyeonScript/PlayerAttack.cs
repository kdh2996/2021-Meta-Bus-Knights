using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


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
        playerInput = GetComponent<PlayerInput>();

        // 20210812_KDH udpsocket ������Ʈ ������
        udpSoc = GetComponent<UdpSocket>();
    }

    //���� �ֱ⿡ ���� �����
    void Update()
    {
        // 20210812 KDH �� ���۽� ���� �߻� ����
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
                playerInput.setChangeCharacterState(1);
                fireMagic();
            }   
            else if(udpSoc.curMagicStr == "thunderStorm" && isReadytoCast_Magic)
            {
                isReadytoCast_Magic = false;
                Debug.Log("!!! thunderstorm !!!");
                playerInput.setChangeCharacterState(2);
                fireMagic();
            }
            else if(udpSoc.curMagicStr == "ignition" && isReadytoCast_Magic)
            {
                isReadytoCast_Magic = false;
                Debug.Log("*** ignition ***");
                playerInput.setChangeCharacterState(3);
                fireMagic();
            }
            
        }

        udpSoc.isreceivedData = false;

        // ���콺 input���� fireMagic ���� true�� �Ǹ� fireMagic �Լ� ���� 
        if (playerInput.fireMagic == true)
        {
            fireMagic();
        }
    }

    // ���� �߻� �Լ�
    private void fireMagic()
    {
        if (playerInput.changeCharacterState == 0)
        { } //do nothing
        else if (playerInput.changeCharacterState == 1)
        {
            // magic - fireball
            GameObject magic = Instantiate(magicPrefabs[0], magicPosition.position, magicPosition.rotation);
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }
        else if (playerInput.changeCharacterState == 2)
        {
            // magic - thunderstorm
            GameObject magic = Instantiate(magicPrefabs[1], magicPosition.position, magicPosition.rotation); 
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }
        else if (playerInput.changeCharacterState == 3)
        {
            // magic - ignition
            GameObject magic = Instantiate(magicPrefabs[2], magicPosition.position, magicPosition.rotation);
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }

    }
}
