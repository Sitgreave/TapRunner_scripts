
using System.Collections;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] RunStepClips;
    public AudioClip[] JumpClips;
    public AudioClip[] BridgeClips;
    public AudioClip[] HandGrabClips;
    public AudioClip[] BottleGrabClips;
    public AudioClip[] BirdClips;
    public AudioClip BonkSound;
    public AudioClip FallSound;
    public AudioClip StopSound;
    public AudioClip RunToDiveClip;
    public AudioClip SwimmingClip;
    public AudioSource audioSource;

    public static int needSound;

    private bool allow = true;

    private void Start()
    {
        needSound = SaveSystem.GetState("Sound");
        StartCoroutine(BirdsSound());
    }
    private void AllowNewStepSound()
    {
        allow = true;
    }

    int localAudioIndex = 0;
    public void RunSoundPlay()
    {
        if (allow)
        {

         PlaySound(GetRandomClip(RunStepClips));
            allow = false;
            Invoke(nameof(AllowNewStepSound), 0.15f);
        }
    }
    public void FallSoundPlay()
    {
      PlaySound(FallSound);
    }
    public void StopSoundPlay()
    {
      PlaySound(StopSound);
    }
    public void BonkSoundPlay()
    {
      PlaySound(BonkSound);
    }
    public void BottleBrabPlay()
    {
      PlaySound(GetRandomClip(BottleGrabClips));
    }
    public void JumpSoundPlay()
    {
        PlaySound(JumpClips[localAudioIndex]);
        if (localAudioIndex == 0) localAudioIndex++;
        else localAudioIndex = 0;
    }

    public void RunToDiveSoundPlay()
    {

      PlaySound(RunToDiveClip);
    }

    public void SwimmingSound()
    {
        PlaySound(SwimmingClip);
    }

    public void BridgeSound()
    {
      PlaySound(GetRandomClip(BridgeClips));
    }


    public IEnumerator BirdsSound()
    {
        while (true)
        {
            PlaySound(GetRandomClip(BirdClips));
            yield return new WaitForSeconds(Random.Range(5, 15));
        }
    }

    public void HandGrabSound()
    {
      PlaySound(GetRandomClip(HandGrabClips));
        // allow = false;
        //  Invoke(nameof(AllowNewStepSound), 0.15f);
    }
    private AudioClip GetRandomClip(AudioClip[] audioClip)
    {
        int lastClipID = 0;
        int ID = 0;
        while (ID == lastClipID) { ID = Random.Range(0, audioClip.Length); }
        return audioClip[ID];
    }
    private void PlaySound(AudioClip audioClip)
    {
        if (needSound == 1)
        {
            
            audioSource.pitch = Random.Range(0.9f, 1.2f);
            audioSource.PlayOneShot(audioClip);
        }
    }
}
