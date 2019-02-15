﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルの初期化ステート
/// </summary>
public class BattleStateInit : IState<BattleContext> {

	public void ExecuteEntry(BattleContext context) {
		Debug.LogWarning("[Entry] Battle State : Init");
	}

	public void ExecuteUpdate(BattleContext context) {

		// 初期化完了したなら
		if (Init()) {
			// 攻守決定ステートへ遷移
			context.ChangeState(context.stateOffensiveDecision);
		}
	}

	public void ExecuteExit(BattleContext context) {
		Debug.LogWarning("[Exit] Battle State : Init");
	}

	/// <summary>
	/// 初期化処理
	/// </summary>
	bool Init() {

		if (OperatorManager.Instance.PlayerController && OperatorManager.Instance.ComputerController) {
			return true;
		}

		return false;
	}
}