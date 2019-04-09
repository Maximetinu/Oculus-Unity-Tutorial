using UnityEngine;

public static class OVRVibration
{
    public static void Trigger(AudioClip vibrationAudio, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);
        VibeOnCorrespondingController(clip, controller);
    }

    public static void Trigger(int iterations, int frequency, int strength, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iterations; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        VibeOnCorrespondingController(clip, controller);
    }

    static void VibeOnCorrespondingController(OVRHapticsClip clip, OVRInput.Controller controller)
    {
        if (controller == OVRInput.Controller.LTouch)
        {
            // Trigger on left controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controller == OVRInput.Controller.RTouch)
        {
            // Trigger on right controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
}
