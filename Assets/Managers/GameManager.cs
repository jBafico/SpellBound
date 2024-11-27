using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
        #region GAME_MANAGER_PROPERTIES

        private const string DEFEAT_SCENE = "Defeat";
        private const string LOADING_SCENE = "Loading";
        private const string VICTORY_SCENE = "Victory";
        [SerializeField] private bool _isGameOver = false; //si termino el juego
        [SerializeField] private bool _isVictory = false; //si se obtuvo victoria
        [SerializeField] private String _nextLevel;

        #endregion

        #region UNITY_EVENTS

        private void Start()
        {
                //Subscripcion al evento
                EventsManager.Instance.OnGameOver += OnGameOver;
        }

        private void Update()
        {
                if (_isGameOver && !_isVictory)
                {
                        Time.timeScale = 1;
                        SceneManager.LoadScene(DEFEAT_SCENE);
                }
                else if (_isGameOver && _isVictory)
                {
                        Time.timeScale = 1;

                        if (_nextLevel == "Victory")
                        {
                                SceneManager.LoadScene(VICTORY_SCENE);
                        }
                        else
                        {
                                LoadingManager.NEXT_LEVEL = _nextLevel;
                                SceneManager.LoadScene(LOADING_SCENE);
                        }
                        
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
        }

        #endregion
}
