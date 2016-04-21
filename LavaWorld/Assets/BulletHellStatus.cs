using UnityEngine;
using System.Collections;

public class BulletHellStatus : LavaEffects {



	public override void  ResetEnemValues(){ //for the future need to override this becuase enemyies are based on random and if this is ued in bh part = issues respawns same place but we need an ovverride to reset values only and not pos 
		wasDestroyed = false;
		gameObject.SetActive(true);
		HitsToDestroy = initialHitsToDestory;}


}
