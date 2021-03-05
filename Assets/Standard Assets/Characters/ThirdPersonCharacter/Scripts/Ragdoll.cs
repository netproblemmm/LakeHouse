using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float killForce = 5f;
    [SerializeField] private bool kill;
    [SerializeField] private bool revive;

    [SerializeField] private Rigidbody[] RBsArray;

    [SerializeField] private Collider[] colls;
    [SerializeField] private Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
        RBsArray = GetComponentsInChildren<Rigidbody>();
        colls = GetComponentsInChildren<Collider>();
        Revive();
    }

    private void Kill()
    {
        kill = false;
        SetRagdoll(true);
        SetMain(false);
    }

    private void Revive()
    {
        revive = false;
        SetRagdoll(false);
        SetMain(true);
    }

    void SetRagdoll(bool active)
    {
        for (int i = 0; i < RBsArray.Length; i++)
        {
            RBsArray[i].isKinematic = !active;
        }

        for (int i = 0; i < colls.Length; i++)
        {
            colls[i].enabled = active;
        }
    }

    void SetMain(bool active)
    {
        anim.enabled = active;
        RBsArray[0].isKinematic = !active;
        colls[0].enabled = active;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Kill();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Revive();
        }
    }
}
