using UnityEngine;
using System.Collections;

public class SensorData : MonoBehaviour // removed static from this, possible issues?
	// static class GlobalClass


{

	public float ShowRespOut;
	public float ShowFaOut;
	private static string m_globalVar = "";
	private static float m_eeg = 1f;
	//	private static int m_state = 0;
	//	private static GameObject technoplaya = null;
	//	public static float eyeCoordinate_x;
	//	public static float eyeCoordinate_y;
	
	//public static float eeg1;

	public static float RespOut;	//relaxation, fades to whie.
	public static float FAOut;  //concentration, goes up and down
	

	// to access just refer to GlobalClass.eeg1
	
	/*
	
	public static string GlobalVar
	{
    	get { return m_globalVar; }
	    set { m_globalVar = value; }
	}
	
	public static float eda 
	{
		get { return m_eda; }
		set { m_eda = value; }
	}
	
		
	public static int state
	{
		get { return m_state; }
		set { m_state = value; }
	}
*/

	void Update()
	{
		ShowRespOut = RespOut;
		ShowFaOut = FAOut;
	}



}






