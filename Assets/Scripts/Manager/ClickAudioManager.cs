using UnityEngine;

/// <summary>
/// ClickAudioManagerクラス
/// </summary>
public class ClickAudioManager : MonoBehaviour
{
    [Header("AudioSorce")]
    [SerializeField,Tooltip("AudioSource")] AudioSource _audioSource;

    public void ClickAudio()
    {
        _audioSource.Play();
    }
}
