using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{

    public Transform bulletImpact;
    public Transform explosion;
    public Transform crossHair;

    // �߻� ��ü�� �ӵ�
    public float speed = 15f;

    // ������Ʈ�� ���� ��� ���� ������Ʈ
    private Rigidbody magicRigidbody;

    //������ ������ ��ġ�� ������ ����
    Vector3 originSize;

    //���� ���߽� ȿ��
    public GameObject magicEffectPrefab;

    void Start()
    {
        magicRigidbody = GetComponent<Rigidbody>();
        magicRigidbody.velocity = transform.forward * speed;

        //���� �ð��� ������ �ı�
        Destroy(gameObject, 4f);
    }

    // �浹 �� ȿ��
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Tower"))
        {
            Debug.Log("���ߵ�!");
            GameObject magicEffect = Instantiate(magicEffectPrefab, collision.transform.position, collision.transform.rotation);
            Destroy(magicEffect, 2f);
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }

}
