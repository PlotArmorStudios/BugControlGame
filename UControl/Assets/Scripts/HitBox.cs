using System;
using System.Collections;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerRenderer;

    public Color _playerColorOnActivate;
    public float Duration { get; set; }

    private void OnEnable()
    {
        StartCoroutine(ConvertPlayerColor());
    }

    private IEnumerator ConvertPlayerColor()
    {
        while (Duration > 0)
        {
            _playerRenderer.color =
                Color.Lerp(_playerRenderer.color, _playerColorOnActivate, 10f * Time.deltaTime);
            Duration -= .1f;
        }

        yield return _playerRenderer.color = _playerColorOnActivate;
        
        StartCoroutine(RevertPlayerColor());
    }

    private IEnumerator RevertPlayerColor()
    {
        Duration = 3f;
        
        while (Duration > 0)
        {
            _playerRenderer.color = Color.Lerp(_playerRenderer.color, Color.white, 10f * Time.deltaTime);
            Duration -= .1f;
            yield return null;
        }
    }
}