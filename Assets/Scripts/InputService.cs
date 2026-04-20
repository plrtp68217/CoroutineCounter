using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public const int LeftMouseButtonCode = 0;

    public Action OnLeftMouseButtonClick;

    private void Update()
    {
        bool LeftMouseButtonIsClicked = Input.GetMouseButtonDown(LeftMouseButtonCode);

        if (LeftMouseButtonIsClicked)
        {
            OnLeftMouseButtonClick?.Invoke();
        }
    }
}