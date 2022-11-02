using System;
using System.Collections.Generic;

using UnityEngine;
public class fingermovement : MonoBehaviour
{
    public GameObject lefthand;
    public GameObject righthand;

    private float remapvalue = -75.0f; //degrees


    [Range(0f, 1f)]
    public List<float> input = new List<float>();
    List<GameObject> objs = new List<GameObject>();

    


    void Start()
    {
        assignDigit(lefthand, objs);
        assignDigit(righthand, objs);

        for (int i = 0; i < objs.Count; i++)
        {
            input.Add(0f);
            
            ResetTransforms(objs[i]);
            ResetTransforms(objs[i].transform.GetChild(0).gameObject);
            ResetTransforms(objs[i].transform.GetChild(0).GetChild(0).GetChild(0).gameObject);

        }
        
    }
    void ResetTransforms(GameObject obj)
    {
        GameObject newParent = new GameObject();
        newParent.name = "newParent_" + obj.name;
        newParent.transform.SetParent(obj.transform.parent, false);
        newParent.transform.SetPositionAndRotation(obj.transform.position, obj.transform.rotation);
        newParent.transform.localScale = obj.transform.localScale;
        obj.transform.SetParent(newParent.transform, true);
    }
    void Update()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            fingermove(objs[i], input[i]);
        }
        //Debug.Log(objs[2].transform.localEulerAngles);
    }

    void fingermove(GameObject parent, float input)//parent digit bone, float value from vr controller input (0.0->1.0)
    {
        float angle = Remap(input,remapvalue);//converts normalize value to relative angle to bone
        float angle2 = Remap(input,remapvalue);
        Vector3 localAngle = parent.transform.localEulerAngles;


        Vector3 eularangles = new Vector3(angle, localAngle.y, localAngle.z);
        parent.transform.localEulerAngles = new Vector3(angle, localAngle.y, localAngle.z);//parent bone

        //parent.transform.rotation = parent.transform.rotation * Quaternion.Euler(eularangles);


        Vector3 localangle1 = parent.transform.GetChild(0).GetChild(0).localEulerAngles;
        localangle1 = new Vector3(0, 0, 0);
        parent.transform.GetChild(0).GetChild(0).localEulerAngles = new Vector3(angle2, localangle1.y, localangle1.z);//middle bone

        Vector3 localangle2 = parent.transform.GetChild(0).GetChild(0).GetChild(0).localEulerAngles;
        localangle2 = new Vector3(0, 0, 0);
        parent.transform.GetChild(0).GetChild(0).GetChild(0).localEulerAngles = new Vector3(angle2, localangle2.y, localangle2.z);//end bone

    }

    float Remap(float source, float targetTo)
    {

        float sourceTo = 1;
        float sourceFrom = 0;
        float targetFrom = 0;

        return targetFrom + (source - sourceFrom) * (targetTo - targetFrom) / (sourceTo - sourceFrom);
    }

    public void assignDigit(GameObject hand, List<GameObject> digits)
    {
        List<GameObject> local = new List<GameObject>();

        foreach (Transform fingies in hand.transform)
        {
            local.Add(fingies.gameObject);
            //Debug.Log(fingies.name);
        }
        int index = 0;
        int mid = 0;
        int thumb = 0;
        //reorder list to index, middle, thumb
        for (int i = 0; i < hand.transform.childCount; i++)
        {
            if (hand.transform.GetChild(i).name.Contains("index"))
            {
                index = i;
            }
            if (hand.transform.GetChild(i).name.Contains("middle"))
            {
                mid = i;
            }
            if (hand.transform.GetChild(i).name.Contains("thumb"))
            {
                thumb = i;
            }
        }

        digits.Add(hand.transform.GetChild(index).gameObject);
        digits.Add(hand.transform.GetChild(mid).gameObject);
        digits.Add(hand.transform.GetChild(thumb).gameObject);
    }
}
