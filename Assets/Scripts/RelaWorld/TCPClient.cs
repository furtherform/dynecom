using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;



public class TCPClient : MonoBehaviour
{
	private System.Threading.Thread myThread;
    public bool doit = false;
    public float upsi = 0.0F;
    float posi = 0.0F;

    // Use this for initialization
	public static bool running = true;



    void Start()
    {
        TCPClientThread myTCPClient = new TCPClientThread(this);
        myThread = new System.Threading.Thread(new ThreadStart(myTCPClient.myTCPClient));
        myThread.Start();

      //  GlobalClass.EDA = 1;
		eeg_data.eeg2 = 0;
		eeg_data.eeg1 = 0;



    }


    // Update is called once per frame
    void Update()
    {
        if (doit)
        {
            //Debug.Log("Eyecoordinates are: " + GlobalClass.eyeCoordinate_x + " " + GlobalClass.eyeCoordinate_y);
            doit = false;
        }   
    }
	void OnApplicationQuit()
	{
		Debug.Log ("Application quit");
		running = false;
	}
	void OnDestroy()
	{
		running = false;
	}
}

public class TCPClientThread
{

    TCPClient openvibeClient;
	TcpClient myClient;
	int numberOfChannels;
	int numberOfAlphaChannels;
	int numberOfThetaChannels;
	float AlphaPower;
	float ThetaPower;
	int BaselineLength;
	float AlphaMin;
	float ThetaMin;
	float AlphaMax;
	float ThetaMax;

	float AlphaRange = 0.01f;
	float ThetaRange = 0.01f;

	string StaticIP = "130.233.50.206";


   public TCPClientThread(TCPClient c)
    {
      openvibeClient= c;
	//	numberOfAlphaChannels = 31;
	//	numberOfThetaChannels = 31;
	//	BaselineLength = 30;
		numberOfAlphaChannels = 6;
		numberOfThetaChannels = 2;
		BaselineLength = 2;

		AlphaMin = 1000000;
		ThetaMin = 1000000;
		AlphaMax = -1;
		ThetaMax = -1;
    }

    public void myTCPClient()
    {
		if (PlayerPrefs.HasKey ("StaticIPStored")) 
		{ StaticIP = PlayerPrefs.GetString("StaticIPStored");		
			Debug.Log(StaticIP + "from save");
		}




        float tmp_EDA = 0f;
        string input, stringData;
        byte[] message = new byte[128];
        int bytesRead;
	
		myClient = null;
        Debug.Log("running tcp client");


		myClient = new TcpClient();
		//myClient.Connect("localhost", 9995);
	    myClient.Connect(StaticIP, 9995);
		Debug.Log("running tcp client2");

        NetworkStream myClientStream = myClient.GetStream();
	
        while (true)
        {
			Debug.Log("running tcp client3");
            bytesRead = 0;
			Debug.Log("running tcp client4");
            try
            {

                bytesRead = myClientStream.Read(message, 0, 128);
		
            }
            catch (Exception e)
            {
                Debug.Log("Caugth exception : " + e);
                break;
            }
            // If we received 0 bytes the connection was closed.
			Debug.Log("running tcp client7");

            if (bytesRead == 0)
            {
                Debug.Log("Connection closed.");
                break;
            }
			Debug.Log ("Something was read from the server");
           stringData = Encoding.ASCII.GetString(message, 0, bytesRead);
            string[] words = stringData.Split(',');
           
			// Assume 2x32 channels of data.
			numberOfChannels = words.GetLength(0);
			if  (numberOfChannels  != (numberOfAlphaChannels + numberOfThetaChannels)) {
				Debug.Log ("Invalid number of channels: "+ numberOfChannels);
				continue;
			}
			AlphaPower = 0;
			ThetaPower = 0;
			try
            {
				for (int i = 0; i < numberOfAlphaChannels; i++)
				{
					AlphaPower = (float)Convert.ToDouble (words[i]) + AlphaPower;
				}
				AlphaPower = AlphaPower/numberOfAlphaChannels;
			

				for (int i = numberOfAlphaChannels; i < (numberOfAlphaChannels+numberOfThetaChannels);
				     i++){
					ThetaPower = (float)Convert.ToDouble (words[i]) + ThetaPower;
					 	
				}
				ThetaPower = ThetaPower/numberOfThetaChannels;
				Debug.Log ("Relax: " + eeg_data.eeg2);
			
		//		if (BaselineLength > 0){
				
				

					if(AlphaPower < AlphaMin){
						AlphaMin = AlphaPower;
					}
					if(ThetaPower < ThetaMin){
						ThetaMin = ThetaPower;
					}
					
					if(AlphaPower > AlphaMax){
						AlphaMax = AlphaPower;
					}
					if(ThetaPower > ThetaMax){
						ThetaMax = ThetaPower;
					}
				AlphaRange = AlphaMax - AlphaMin;
				ThetaRange = ThetaMax - ThetaMin;

			//	Debug.Log("AlphaRange: " + AlphaRange);
				Debug.Log("ThetaRange: " + ThetaRange);
				Debug.Log("ThetaMin: " + ThetaMin);
				Debug.Log("ThetaMax: " + ThetaMax);
				Debug.Log("thetapower: " + ThetaPower);

				Debug.Log(" Toimii kuin junan vessa");
		
				Debug.Log("AlphaMin: " + AlphaMin);
				Debug.Log("AlphaMax: " + AlphaMax);
				Debug.Log("Alphapower: " + AlphaPower);
				Debug.Log("AlphaRange: " + AlphaRange);

				if(BaselineLength > 0)
					eeg_data.eeg2 = 0;
				else 
					eeg_data.eeg2 = (AlphaPower-AlphaMin)/AlphaRange - 0.2f;


				if(BaselineLength >0 )
					eeg_data.eeg1 = 0;
				else
					eeg_data.eeg1 = (ThetaPower-ThetaMin)/ThetaRange -0.2f;
				

				if (BaselineLength == 1){
						AlphaRange = AlphaMax - AlphaMin;
						ThetaRange = ThetaMax - ThetaMin;
						Debug.Log("AlphaRange: " + AlphaRange);
						Debug.Log("ThetaRange: " + ThetaRange);
						Debug.Log("ThetaMin: " + ThetaMin);
						Debug.Log("ThetaMax: " + ThetaMax);
						Debug.Log("BaselineLength: " + BaselineLength);
					}	
				if (BaselineLength > 0)
					BaselineLength--;
					/*
					if(AlphaPower < AlphaMin){
						AlphaMin = AlphaPower;
					}
					if(ThetaPower < ThetaMin){
						ThetaMin = ThetaPower;
					}
					
					if(AlphaPower > AlphaMax){
						AlphaMax = AlphaPower;
					}
					if(ThetaPower > ThetaMax){
						ThetaMax = ThetaPower;
					}*/

	//			}

			}
				catch (Exception e)
            {
                Debug.Log("Vituiks man" + e.ToString());
				continue;
            }

			Debug.Log ("input from server " + stringData);
			Debug.Log ("Alpha power is: " + AlphaPower);
			Debug.Log ("Theta power is: " + ThetaPower);
			
        }
		//myClient.Close();
   //     Console.WriteLine("Disconnecting...");
 //     myListener.Shutdown(SocketShutdown.Both);
   //    myListener.Close();
    }
	~TCPClientThread() {
		myClient.Close();
	}
}
