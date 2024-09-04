using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        #region GAME_MANAGER_PROPERTIES

        [SerializeField] private bool _isGameOver = false; //si termino el juego
        [SerializeField] private bool _isVictory = false; //si se obtuvo victoria
        [SerializeField] private TMP_Text _gameOverMessage;
        

        #endregion

        #region UNITY_EVENTS

        private void Start()
        {
                //seteo basico de mensaje, pero vacio
                _gameOverMessage.text = String.Empty;
                //Subscripcion al evento
                EventsManager.Instance.OnGameOver += OnGameOver;
        }

        #endregion

        #region GAME_MANAGER_METHODS

        private void OnGameOver(bool isVictory)
        {
                _isGameOver = true;
                //Aca tengo que frenar todo
                _isVictory = isVictory;
                
                //Preparar el mensaje de texto
                _gameOverMessage.text = isVictory ? "¡¡¡VICTORY!!!" : "DEFEAT :(";
                _gameOverMessage.color = isVictory ? Color.green : Color.red;
        }

        #endregion
}
