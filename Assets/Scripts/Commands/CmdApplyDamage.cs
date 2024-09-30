using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdApplyDamage : ICommand
{
    private IDamageable _damageable;
    private float _amount;

    public CmdApplyDamage(IDamageable damageable, float amount)
    {
        _damageable = damageable;
        _amount = amount;
    }

    #region ICOMMAND_METHODS

    public void Do()
    {
        _damageable.TakeDamage(_amount);
    }

    #endregion
}
