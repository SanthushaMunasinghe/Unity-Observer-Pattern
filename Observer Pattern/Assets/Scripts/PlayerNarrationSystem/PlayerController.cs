using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Subject
{
    public void JumpPressed()
    {
        NotifyObservers(PlayerActions.Jump);
    }

    public void WalkPressed()
    {
        NotifyObservers(PlayerActions.Walk);
    }

    public void AttackPressed()
    {
        NotifyObservers(PlayerActions.Attack);
    }
}
