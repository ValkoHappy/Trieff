using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Serena : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float _maximumVolume;
    [SerializeField] private float _minimunVolume;

    private AudioSource _audioSource;
    private Coroutine _fadeInJob;
    private float _target = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minimunVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.Play();
        StartCoroutine(FadeIn());
    }

    private void ChangeVolume()
    { 
        if (_audioSource.volume == _maximumVolume)
        {
            _target = _minimunVolume;
        }
        else if (_audioSource.volume == _minimunVolume)
        {
            _target = _maximumVolume;
        }
    }

    private IEnumerator FadeIn()
    {
        while (_audioSource.volume != _target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, speed * Time.deltaTime);
            ChangeVolume();
            yield return null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_audioSource.volume != _minimunVolume)
        {
            _target = _minimunVolume;
            FadeIn();
            _audioSource.Stop();
            StopCoroutine(FadeIn());
        }
    }
}

