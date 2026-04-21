using UnityEngine;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        Debug.Log(value);
    }
}
