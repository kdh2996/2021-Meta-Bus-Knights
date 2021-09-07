using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    // test prefab�� ������ ��ġ
    public GameObject location;
    // VR UI test�� prefab
    public GameObject cube;

    public GameObject fingerTip;


    // �հ���, UI
    bool isPointing;
    bool isTouching;
    Vector3 fingerTipForward;
    float touchDistance;

    void Start()
    { 
        fingerTipForward = fingerTip.transform.TransformDirection(Vector3.forward);
        touchDistance = 0.01f;
        isPointing = false;
        isTouching = false;
    }

    void Update()
    {
        // �����Ӹ��� üũ 
        CheckIsPointing();

        if (Physics.Raycast(fingerTip.transform.position, fingerTipForward, out RaycastHit ray, touchDistance))
        {
            Collider rayCollider = ray.collider;
            if ((rayCollider.gameObject.tag=="Button") && isPointing && !isTouching)
            {
                isTouching = true;
                // ��ư�� �۵��ϴ��� test�� prefab ����
                Instantiate(cube, location.transform.position, new Quaternion(), gameObject.transform);

            }
            else 
            {
                isTouching = false;

            }
        }


    } 

    void CheckIsPointing()
    {
        if (!OVRInput.Get(OVRInput.NearTouch.SecondaryIndexTrigger))
        {
            isPointing = true;
        }
        else
        {
            isPointing = false;
        }
    }
}