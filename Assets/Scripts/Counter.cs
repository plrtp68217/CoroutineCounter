using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] InputService _inputService;

    private float _value = 0;
    private Coroutine _coroutine;

    private void HandleMouseButtonClick()
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
        while (true)
        {
            Debug.Log(_value++);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnEnable()
    {
        _inputService.OnLeftMouseButtonClick += HandleMouseButtonClick;
    }

    private void OnDisable()
    {
        _inputService.OnLeftMouseButtonClick -= HandleMouseButtonClick;
    }
}
