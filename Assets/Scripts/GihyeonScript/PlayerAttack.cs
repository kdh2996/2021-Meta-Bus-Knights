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


    //���� �������� �����Ǵ� ���
    public GameObject magicPrefabPos;

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
            if (udpSoc.curMagicStr == "fireball")
            {
                Debug.Log("!!!!!!!fireball");
                playerInput.setChangeCharacterState(1);
            }   
            else if(udpSoc.curMagicStr == "thunderStorm")
            {
                Debug.Log("!!!!!!thunderstorm");
                playerInput.setChangeCharacterState(2);
            }
            else if(udpSoc.curMagicStr == "ignition")
            {
                Debug.Log("!!!!!!ignition");
                playerInput.setChangeCharacterState(3);
            }
            
            fireMagic();
        }

        udpSoc.isreceivedData = false;

        if (playerInput.fireMagic == true)
        {
            fireMagic();
        }
    }

    private void fireMagic()
    {
        if (playerInput.changeCharacterState == 0)
        { } //do nothing
        else if (playerInput.changeCharacterState == 1)
        {
            // magic - fireball
            // magic�� magicPrefabPos�� �����Ѵ�.
            GameObject magic = Instantiate(magicPrefabs[0], magicPosition.position, magicPosition.rotation);
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }
        else if (playerInput.changeCharacterState == 2)
        {
            // magic - thunderstorm
            // magic�� magicPrefabPos�� �����Ѵ�.
            GameObject magic = Instantiate(magicPrefabs[1], magicPosition.position, magicPosition.rotation); 
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }
        else if (playerInput.changeCharacterState == 3)
        {
            // magic - ignition
            // magic�� magicPrefabPos�� �����Ѵ�.
            GameObject magic = Instantiate(magicPrefabs[2], magicPosition.position, magicPosition.rotation);
                                                                                                             //magic.transform.LookAt(magicPosition.forward);
        }

    }
}