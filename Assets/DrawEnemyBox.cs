//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DrawEnemyBox : MonoBehaviour {

//    public float xExtents;
//    public float yExtents;



//	void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Vector3 TR = transform.position + new Vector3(xExtents, yExtents);
//        Vector3 BL = transform.position - new Vector3(xExtents, yExtents);
//        Vector3 BR = new Vector3(TR.x,BL.y);
//        Vector3 TL = new Vector3(BL.x, TR.y);

//        Gizmos.DrawLine(TR, TL);
//        Gizmos.DrawLine(TL, BL);
//        Gizmos.DrawLine(BL, BR);
//        Gizmos.DrawLine(BR, TR);


//    }
//}
