using UnityEngine;
using System.Collections;

static class GlobalClass

{
    private static string m_globalVar = "";
	private static float m_eda = 1f;
	private static int m_state = 0;
	private static GameObject technoplaya = null;
	public static float eyeCoordinate_x;
	public static float eyeCoordinate_y;
	public static float relaxation;
	public static float concentration;

	public static string GlobalVar
	{
    	get { return m_globalVar; }
	    set { m_globalVar = value; }
	}
	
	public static float EDA 
	{
		get { return m_eda; }
		set { m_eda = value; }
	}
	
		
	public static int state
	{
		get { return m_state; }
		set { m_state = value; }
	}
	/*
	public static GameObject tp
	{
		get { return technoplaya; }
		set { technoplaya = value; }
	}*/

}