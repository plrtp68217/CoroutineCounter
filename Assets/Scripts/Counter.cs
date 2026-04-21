using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private float _delay = 0.5f;

    private int _value = 0;
    private Coroutine _coroutine;
    private bool _enabled;

    public Action<float> ValueChanged;

    private void OnEnable()
    {
        _inputService.Pressed += OnPressed;
        _enabled = true;
    }

    private void OnDisable()
    {
        _inputService.Pressed -= OnPressed;
        _enabled = false;
    }

    private void OnPressed()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(DisplayCounterValue());
        }
    }

    private IEnumerator DisplayCounterValue()
    {
        WaitForSeconds wait = new(_delay);

        while (_enabled)
        {
            ValueChanged?.Invoke(_value++);

            yield return wait;
        }
    }
}
