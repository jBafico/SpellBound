using System;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueManager : MonoBehaviour
{
    #region SINGLETON

    static public EventQueueManager Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
        
    }

    #endregion
    
    /* Etapas 
    1. Agrupar comandos bajo una cola 
    2.  Cola o lista donde almacenar los comandos
    3. Recorrerla y ejecutar comandos (aca se pueden aplicar filtros si se necesita) */

    //Etapa 2
    private Queue<ICommand> _commands = new Queue<ICommand>();

    //Etapa 1
    public void AddCommandToQueue(ICommand command)
    {
        _commands.Enqueue(command);
    }

    //Etapa 3
    private void Update()
    {
        while (_commands.Count>0)
        {
            ICommand command = _commands.Dequeue();
            
            //Aca meter filtros
            command.Do();
        }
    }
}
