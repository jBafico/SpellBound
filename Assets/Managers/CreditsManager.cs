using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
        private const string MENU_SCENE = "Menu";
        private const string LEVEL_1_SCENE = "Loading";

        [SerializeField] private Button _actionReturn;
        [SerializeField] private Button _actionPlay;

        private void Start()
        {
                //Reseteo el timescale por si volvio al menu despues de perder o ganar
                Time.timeScale = 1;
                //We reset the spell of the mage to the basic one
                MageSpell.mageGunNumber = 0;
                LoadingManager.NEXT_LEVEL = "Level 1";
                _actionReturn.onClick.AddListener(()=> LoadSceneByName(MENU_SCENE));
                _actionPlay.onClick.AddListener(() => LoadSceneByName(LEVEL_1_SCENE));
        }

        private void LoadSceneByName(string name) => SceneManager.LoadScene(name);
}
