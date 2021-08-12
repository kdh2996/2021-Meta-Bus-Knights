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
    public GameObject magicPrefab;

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
        if ( udpSoc.curMagicStr == "fireball" && udpSoc.isreceivedData)
        {
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
        GameObject magic = Instantiate(magicPrefab, magicPosition.position, magicPosition.rotation); // magic�� magicPrefabPos�� �����Ѵ�.
        //magic.transform.LookAt(magicPosition.forward);
    }

}
