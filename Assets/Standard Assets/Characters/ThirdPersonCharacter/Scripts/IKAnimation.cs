using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKAnimation : MonoBehaviour
{
    [SerializeField] private Animator animatorGO;
    [SerializeField] private Transform handObj;
    [SerializeField] private Transform lookObj;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform head;

    [SerializeField] private bool ikActive;
    [SerializeField] private float rightHandWeight = 1;
    [SerializeField] private float leftHandWeight = 1;

    [SerializeField] private float lookObjDistance;

    void Start()
    {
        animatorGO = GetComponent <Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (ikActive)
        {
            if (handObj)
            {
                animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
                animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);

                animatorGO.SetIKPosition(AvatarIKGoal.RightHand, handObj.position);
                animatorGO.SetIKRotation(AvatarIKGoal.RightHand, handObj.rotation);

                animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
                animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);

                animatorGO.SetIKPosition(AvatarIKGoal.LeftHand, handObj.position);
                animatorGO.SetIKRotation(AvatarIKGoal.LeftHand, handObj.rotation);
            }

            if (lookObj)
            {
                lookObjDistance = Vector3.Distance(lookObj.position, head.position);
                if (lookObjDistance <= 2)
                {
                    animatorGO.SetLookAtWeight(1);
                }
                else
                {
                    animatorGO.SetLookAtWeight(0);
                }
                animatorGO.SetLookAtPosition(lookObj.position);
            }
        }
        else
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            animatorGO.SetLookAtWeight(0);
        }
    }
}
