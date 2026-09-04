using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class StartScreen : MonoBehaviour
{

    [SerializeField] private GameObject startButton;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(startButton);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        StartGame();
    }
}

