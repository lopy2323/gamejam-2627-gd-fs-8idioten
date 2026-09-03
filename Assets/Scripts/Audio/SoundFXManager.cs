using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    static public SoundFXManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySoundFX(AudioClip AudioClip, Transform spawnTransform, float volume)
    {
        AudioSource audiosourcespawn = Instantiate(audioSource, spawnTransform.position, Quaternion.identity);
        // give clip to play
        audiosourcespawn.clip = AudioClip;
        //valume
        audiosourcespawn.volume = volume;
        //startsound
        audiosourcespawn.Play();
        //destroy logic

        float clipLength = audiosourcespawn.clip.length;
        Destroy(audiosourcespawn.gameObject, clipLength);



    }




}
