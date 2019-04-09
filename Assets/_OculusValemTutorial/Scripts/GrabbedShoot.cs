using UnityEngine;

public class GrabbedShoot : MonoBehaviour
{
    public OVRInput.Button shootInput;

    SimpleShoot shootBehaviour;
    OVRGrabbable grabbable;
    new AudioSource audio;

    void Start()
    {
        shootBehaviour = GetComponent<SimpleShoot>();
        grabbable = GetComponent<OVRGrabbable>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (grabbable.isGrabbed && OVRInput.GetDown(shootInput, grabbable.grabbedBy.Controller))
        {
            if (audio)
            {
                audio.Play();
                OVRVibration.Trigger(audio.clip, grabbable.grabbedBy.Controller);
            }

            shootBehaviour.TriggerShoot();
        }
    }
}
