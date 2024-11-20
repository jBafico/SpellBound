using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        #region GAME_MANAGER_PROPERTIES

        private const string MENU_SCENE = "Menu";
        [SerializeField] private bool _isGameOver = false; //si termino el juego
        [SerializeField] private bool _isVictory = false; //si se obtuvo victoria
        [SerializeField] private TMP_Text _gameOverMessage;
        [SerializeField] private String _nextLevel;
        

        #endregion

        #region UNITY_EVENTS

        private void Start()
        {
                //seteo basico de mensaje, pero vacio
                _gameOverMessage.text = String.Empty;
                //Subscripcion al evento
                EventsManager.Instance.OnGameOver += OnGameOver;
        }

        private void Update()
        {
                if (_isGameOver && !_isVictory && Input.GetKey(KeyCode.Escape))
                {
                        Time.timeScale = 1;
                        SceneManager.LoadScene(MENU_SCENE);
                }
                else if (_isGameOver && _isVictory && Input.GetKey(KeyCode.Space))
                {
                        Time.timeScale = 1;
                        SceneManager.LoadScene(_nextLevel);
                }
        }

        #endregion

        #region GAME_MANAGER_METHODS

        private void OnGameOver(bool isVictory)
        {
                _isGameOver = true;
                //Aca tengo que frenar todo
                Time.timeScale = 0;
                _isVictory = isVictory;
                
                //Preparar el mensaje de texto
                _gameOverMessage.text = isVictory ? "VICTORY!\n PRESS ESC TO GO TO MENU" : "DEFEAT\n PRESS ESC TO GO TO MENU";
                _gameOverMessage.color = isVictory ? Color.green : Color.red;
        }

        #endregion
}
