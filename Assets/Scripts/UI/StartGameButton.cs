using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class StartGameButton : MonoBehaviour
{
    [SerializeField] private Button _button;


    public UnityAction GameStarted;

    private void OnEnable()
    {
        _button.onClick.AddListener(StartGame);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartGame);
    }
    public void StartGame()
    {
        GameStarted?.Invoke();
        _button.gameObject.SetActive(false);
    }
}
