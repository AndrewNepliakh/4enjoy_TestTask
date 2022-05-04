using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class Darker : MonoBehaviour, IDarker
    {
        public Action OnComplete;

        [SerializeField] private Image _darkerImage;
        private float _fadeSpeed = 2.0f;

        private Coroutine _fadeInRoutine;
        private Coroutine _fadeOutRoutine;

        public void FadeInDarker()
        {
            if (_fadeInRoutine == null)
                _fadeInRoutine = StartCoroutine(FadeInRoutine());
            else
            {
                StopCoroutine(_fadeInRoutine);
                _fadeInRoutine = StartCoroutine(FadeInRoutine());
            }
        }

        public void FadeOutDarker()
        {
            if (_fadeOutRoutine == null)
                _fadeOutRoutine = StartCoroutine(FadeOutRoutine());
            else
            {
                StopCoroutine(_fadeOutRoutine);
                _fadeOutRoutine = StartCoroutine(FadeOutRoutine());
            }
        }

        private IEnumerator FadeInRoutine()
        {
            var a = 0.0f;
            _darkerImage.color = new Color(_darkerImage.color.r, _darkerImage.color.g, _darkerImage.color.b, a);
            while (_darkerImage.color.a < 0.4f)
            {
                a += Time.deltaTime * _fadeSpeed;
                _darkerImage.color = new Color(_darkerImage.color.r, _darkerImage.color.g, _darkerImage.color.b, a);
                yield return null;
            }
            _darkerImage.color = new Color(_darkerImage.color.r, _darkerImage.color.g, _darkerImage.color.b, 0.5f);
        }
        
        private IEnumerator FadeOutRoutine()
        {
            var a = 0.5f;
            _darkerImage.color = new Color(_darkerImage.color.r, _darkerImage.color.g, _darkerImage.color.b, a);
            while (_darkerImage.color.a > 0.0f)
            {
                a -= Time.deltaTime * _fadeSpeed;
                _darkerImage.color = new Color(_darkerImage.color.r, _darkerImage.color.g, _darkerImage.color.b, a);
                yield return null;
            }
            _darkerImage.color = new Color(_darkerImage.color.r, _darkerImage.color.g, _darkerImage.color.b, 0.0f);
            
            OnComplete?.Invoke();
        }
    }
}