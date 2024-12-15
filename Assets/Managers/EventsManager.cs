using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
        #region UNITY_EVENTS

        //Singleton: instancia unica e irrepetible de una clase
        public static EventsManager Instance;

        private void Awake()
        { 
                if (Instance != null) Destroy(this);
                Instance = this;
        }

        #endregion

        #region GAME_OVER_EVENTS

        //Le pasamos el bool para que sepa si es victoria o derrota
        //Se puede hacer la action sin tipo
        public event Action<bool> OnGameOver;

        public event Action OnBossBeat;

        public event Action<float> OnLifeUpdate;

        public event Action<float> OnManaUpdate;

        //Intensity, timer
        public event Action<float, float> OnTakingDamage;

        public event Action OnTutorialFinished;

        public event Action<GameObject> OnCrateDestroyed;


        public void EventGameOver(bool isVictory)
        {
                if (OnGameOver != null) OnGameOver(isVictory);
        }

        public void EventBossBeat()
        {
                if (OnBossBeat != null) OnBossBeat();
        }

        public void EventTakingDamage(float intensity, float timer)
        {
                if (OnTakingDamage != null) OnTakingDamage(intensity, timer);
        }

        public void EventTutorialFinished()
        {
                if (OnTutorialFinished != null) OnTutorialFinished();
        }

        public void EventCrateDestroyed(GameObject crate)
        {
                if (OnCrateDestroyed != null) OnCrateDestroyed(crate);
        }

        public void EventLifeUpdate(float currentLife) {
                if(OnLifeUpdate != null) OnLifeUpdate(currentLife);
        }

        public void EventManaUpdate(float currentMana) {
                if(OnManaUpdate != null) OnManaUpdate(currentMana);
        }


        #endregion

}