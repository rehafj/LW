using UnityEngine;
using System.Collections;
/// <summary>
/// inhirited class from lava effects - deals with enemy statas  in order to not reset its pos  nor set it active( as iin lava) 
//overrided to just reset eemy health - evrything else is handled by the pooler that is used in scene
///other things are as they are in lava effects 
/// </summary>
public class BulletHellStatus : LavaEffects {



	public override void  ResetEnemValues(){ //for the future need to override this becuase enemyies are based on random and if this is ued in bh part = issues respawns same place but we need an ovverride to reset values only and not pos 
		wasDestroyed = false;
		//gameObject.SetActive(true);
		HitsToDestroy = initialHitsToDestory;}


}
