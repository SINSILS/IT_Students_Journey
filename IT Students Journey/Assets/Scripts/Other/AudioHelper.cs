using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public static AudioHelper instance;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip quizSong;
    [SerializeField]
    private AudioClip tapSound;
    [SerializeField]
    private AudioClip throwSound;
    [SerializeField]
    private AudioClip slimeHitSound;
    [SerializeField]
    private AudioClip slimeDeathSound;


    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            if (instance != this) {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMenuPress() {
        audioSource.clip = tapSound;
        audioSource.Play();
    }

    public void PlayThrowSound() {
        audioSource.clip = throwSound;
        audioSource.Play();
    }

    public void PlayEnemyHit() {
        audioSource.clip = slimeHitSound;
        audioSource.Play();
    }

    public void PlayEnemyDeath() {
        audioSource.clip = slimeDeathSound;
        audioSource.Play();
    }

    public void PlayQuizSong() {
        audioSource.clip = quizSong;
        audioSource.volume = 0.1f;
        audioSource.Play();
        Camera.main.GetComponent<AudioSource>().Pause();
    }
    
    public void StopQuizSong() {
        audioSource.Stop();
        audioSource.volume = 0.02f;
        Camera.main.GetComponent<AudioSource>().UnPause();
    }
}
