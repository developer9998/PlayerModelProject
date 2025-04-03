using System.Collections;
using System.Collections.Generic;
using PlayerModel.Behaviours;
using PlayerModel.Behaviours.IK;
using UnityEngine;

public class TestMoveScript : MonoBehaviour
{
    public Transform head_bone, body_bone, rig, left_hand_bone, right_hand_bone;

    private GameObject target_left, target_right;

    private Vector3 head_local;

    void Start()
    {
        GameObject player_preview = gameObject;
        //player_preview.transform.SetParent(rig);

        player_preview.TryGetComponent(out ModelDescriptor descriptor);
        var preview_descriptor = descriptor;

        target_left = new GameObject("Left Hand Target");
        target_left.transform.SetParent(player_preview.transform);

        target_right = new GameObject("Right Hand Target");
        target_right.transform.SetParent(player_preview.transform);

        var ik = descriptor.gameObject.AddComponent<GorillaIndependentIK>();
        ik.targetLeft = target_left.transform;
        ik.targetRight = target_right.transform;
        ik.leftUpperArm = descriptor.leftHand.transform.parent.parent;
        ik.leftLowerArm = descriptor.leftHand.transform.parent;
        ik.leftHand = descriptor.leftHand.transform;
        ik.rightUpperArm = descriptor.rightHand.transform.parent.parent;
        ik.rightLowerArm = descriptor.rightHand.transform.parent;
        ik.rightHand = descriptor.rightHand.transform;

        head_local = preview_descriptor.head.localPosition;
    }

    public void Update()
    {
        float scale_factor = 1f;
        GameObject player_preview = gameObject;
        player_preview.TryGetComponent(out ModelDescriptor preview_descriptor);

        player_preview.transform.SetPositionAndRotation(rig.position, rig.rotation);
        player_preview.transform.localScale = Vector3.one * scale_factor;
        target_left.transform.rotation = left_hand_bone.rotation * Quaternion.Euler(preview_descriptor.leftHandRotationOffset);
        target_left.transform.position = left_hand_bone.position + target_left.transform.rotation * (preview_descriptor.leftHandPositionOffset * scale_factor);
        target_right.transform.rotation = right_hand_bone.rotation * Quaternion.Euler(preview_descriptor.rightHandRotationOffset);
        target_right.transform.position = right_hand_bone.position + target_right.transform.rotation * (preview_descriptor.rightHandPositionOffset * scale_factor);
        preview_descriptor.body.SetPositionAndRotation(body_bone.position, body_bone.rotation);
        preview_descriptor.head.rotation = head_bone.rotation * Quaternion.Euler(preview_descriptor.headRotationOffset);

        var neck = preview_descriptor.head.parent;
        Vector3 head_position = Quaternion.Inverse(neck.rotation) * (head_bone.position - neck.position);
        head_position += head_local - head_position;
        preview_descriptor.head.position = neck.TransformPoint(head_position) + preview_descriptor.head.rotation * (preview_descriptor.headPositionOffset * scale_factor);
    }
}
