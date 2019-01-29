﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///モンスターのスキルステート
/// </summary>>

public class MonsterStateSkill : IState<MonsterContext> {

    public void ExecuteEntry(MonsterContext context)
    {
        Debug.Log("[Entry] Monster State : Skill");

        BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour._animator.SetTrigger("SkillTrigger");
    }

    public void ExecuteUpdate(MonsterContext context)
    {
        if (BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour._animator.IsInTransition(0))
        {
            BattleManager.Instance.BattleContext.isDone = true;
            context.ChangeState(context.stateIdle);
        }
    }

    public void ExecuteExit(MonsterContext context)
    {
        var nonActive = BattleManager.Instance.NonActiveController.OperatorModel;
        var active = BattleManager.Instance.ActiveController.OperatorModel;

        if (active.monsterBehaviour.MonsterModel.type == Type.ATTACK)
        {
            nonActive.monsterBehaviour.MonsterModel.hp -=
            active.monsterBehaviour.MonsterModel.skillList[active.pencil.Outcome - 1].power;
            
        }
        else if (active.monsterBehaviour.MonsterModel.type == Type.DEFENCE)
        {

        }
        else if (active.monsterBehaviour.MonsterModel.type == Type.HEAL)
        {
            active.monsterBehaviour.MonsterModel.hp += 
                active.monsterBehaviour.MonsterModel.skillList[active.pencil.Outcome - 1].power;

            Debug.Log(BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour.MonsterModel.hp);
        }
        
        Debug.Log("[Exit] Monster State : Skill");
    }
}
