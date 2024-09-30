using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdApplyHeal : ICommand
{
    private IDamageable _damageable;
    private float _amount;

    public CmdApplyHeal(IDamageable damageable, float amount)
    {
        _damageable = damageable;
        _amount = amount;
    }

    #region ICOMMAND_METHODS

    public void Do()
    {
        _damageable.LifeRecover(_amount);
    }

    #endregion
}
