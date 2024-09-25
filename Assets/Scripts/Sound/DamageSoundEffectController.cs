// Agregamos un componente obligatorio -> Esto fueza a que unity agregue 
// el componente si no existe en el objeto.

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DamageSoundEffectController : MonoBehaviour, IListenable
{
    #region IListenable_Properties
    // El audio quedará asignado por inspector
    public AudioClip AudioClip => _audioClip;
    /// SerializeField nos permite exponer una propiedad privada en el inspector
    [SerializeField] private AudioClip _audioClip;

    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    #endregion

    #region IListenable_Methods
    public void InitAudioSource()
    {
        // Asignar el componente AudioSource
        _audioSource = GetComponent<AudioSource>();
        // Asignamos el audio clip al AudioSource
        _audioSource.clip = AudioClip;
    }

    // Reproducir de esta manera evita tener que asignar un clip al source
    public void PlayOnShot() => AudioSource.PlayOneShot(AudioClip);

    // Esta reproducción necesita tener que asignar un clip al source
    public void Play() => AudioSource.Play();

    // Detiene un clip si esta asignado y en reproducción
    public void Stop() => AudioSource.Stop();
    #endregion

    #region Unity_Events
    // Start is called before the first frame update
    void Start()
    {
        InitAudioSource();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
