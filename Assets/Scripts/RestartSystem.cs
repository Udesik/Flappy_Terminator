using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSystem : MonoBehaviour
{
	[SerializeField] private string _sceneName = "SampleScene";
    [SerializeField] private Health _playerHealth;

    private void OnEnable()
    {
        _playerHealth.Died += RestartGame;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= RestartGame;
    }

    private void RestartGame(GameObject player)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
