using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenConfig : MonoBehaviour
{
    [SerializeField] RectTransform _gameField;
    [SerializeField] RectTransform _clickPanel;
    [SerializeField] RectTransform _hud;
    [SerializeField] Camera _camera;
    private Vector3 zero, zero_displaced;

    public static ScreenConfig instance = null;
    public static int Loading = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        InitializeManager();
    }

    private void InitializeManager()
    {
        float gamePanelHeight = Mathf.RoundToInt(Screen.height * 0.05f);
        _gameField.localPosition = new Vector3(0, - gamePanelHeight/2, 0);
        _gameField.sizeDelta = new Vector2(Screen.width, Screen.height - gamePanelHeight);

        _hud.localPosition = new Vector3(0, Screen.height/2 - gamePanelHeight/2, 0);
        _hud.sizeDelta = new Vector2(Screen.width, gamePanelHeight);

        _clickPanel.sizeDelta = _gameField.sizeDelta;
        _clickPanel.localPosition = _gameField.localPosition;

        zero = _camera.ScreenToWorldPoint(Vector3.zero);
        zero_displaced = _camera.ScreenToWorldPoint(new Vector3(0f, -_gameField.localPosition.y * 2, 0f));
        //Application.targetFrameRate = 120;
    }
    
    public Vector3 GetZeroPoint()
    {
        return zero;
    }
    public Vector3 GetDisplacedZeroPoint()
    {
        return zero_displaced;
    }
}
