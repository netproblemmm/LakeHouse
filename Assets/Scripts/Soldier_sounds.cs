using UnityEngine;

public class Soldier_sounds : MonoBehaviour
{
    [SerializeField] private AudioSource _footStep;
    [SerializeField] private AudioSource _gunShot;

    public void PlayFootStep()
    {
        _footStep.Play();
    }

    public void PlayGunShot()
    {
        _gunShot.Play();
    }
}
