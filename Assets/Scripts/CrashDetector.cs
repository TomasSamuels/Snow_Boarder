using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float reloadTime = 0.5f;
    [SerializeField] AudioClip crashSFX;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            FindAnyObjectByType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke(nameof(ReloadScene), reloadTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
