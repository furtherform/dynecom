using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;



public class TCPClientFA : MonoBehaviour
{
    private System.Threading.Thread myThread;
    public bool doit = false;
    public float upsi = 0.0F;
    float posi = 0.0F;

    // Use this for initialization
    public static bool running = true;



    void Start()
    {
        TCPClientThreadFA myTCPClientFA = new TCPClientThreadFA(this);
        myThread = new System.Threading.Thread(new ThreadStart(myTCPClientFA.myTCPClient));
        myThread.Start();

        //  GlobalClass.EDA = 1;
        SensorData.RespOut = 0f;
        SensorData.FAOut = 0f;

    }


    // Update is called once per frame
    void Update()
    {
        if (doit)
        {
            //Debug.Log("Eyecoordinates are: " + GlobalClass.eyeCoordinate_x + " " + GlobalClass.eyeCoordinate_y);
            doit = false;
            SensorData.RespOut = 1f;
            SensorData.FAOut = 1f;
        }
    }
    void OnApplicationQuit()
    {
        Debug.Log("Application quit");
        running = false;
    }
    void OnDestroy()
    {
        running = false;
    }
}

public class TCPClientThreadFA
{

    TCPClientFA openvibeClient;
    TcpClient myClient;
    int numberOfChannels;
    int numberOfAlphaChannels;
    int numberOfThetaChannels;
    float frontalAss;
    float alphaLeft;
    float alphaRight;
    float respiration;
    float prevRespiration;
    int initSteps;
    float faMin;

    float faMax;

    //float ThetaMax;

    float faRange = 0.01f;

    string StaticIP = "127.0.0.1";
    //string StaticIP = "130.223.58.224";


    public TCPClientThreadFA(TCPClientFA c)
    {
        openvibeClient = c;
        //	numberOfAlphaChannels = 31;
        //	numberOfThetaChannels = 31;
        //	BaselineLength = 30;
        numberOfAlphaChannels = 3;

        initSteps = 2;

        faMin = 1000000;
        faMax = -1;
    }



    public void myTCPClient()
    {
        /*      if (PlayerPrefs.HasKey("StaticIPStored"))
              {
                  StaticIP = PlayerPrefs.GetString("StaticIPStored");
                  Debug.Log(StaticIP + "from save");
              }*/




        //  float tmp_EDA = 0f;
        string input, stringData;
        byte[] message = new byte[128];
        int bytesRead;

        myClient = null;
        Debug.Log("running the tcp client function");


        myClient = new TcpClient();
        Debug.Log("new client object created");

        //myClient.Connect("localhost", 9995);
        myClient.Connect(StaticIP, 9995);
        Debug.Log("running tcp client2 - connecting");

        NetworkStream myClientStream = myClient.GetStream();

        while (true)
        {
            Debug.Log("running tcp client3");
            bytesRead = 0;
            Debug.Log("running tcp client4");

            try
            {

                bytesRead = myClientStream.Read(message, 0, 128);
                Debug.Log("reading stream");

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
            Debug.Log("Something was read from the server");
            stringData = Encoding.ASCII.GetString(message, 0, bytesRead);
            string[] words = stringData.Split(',');

            // Assume 2x32 channels of data.
            numberOfChannels = words.GetLength(0);
            if (numberOfChannels != (numberOfAlphaChannels + numberOfThetaChannels))
            {
                Debug.Log("Invalid number of channels: " + numberOfChannels);
                continue;
            }

            try
            {

                alphaLeft = (float)Convert.ToDouble(words[0]);
                alphaRight = (float)Convert.ToDouble(words[1]);
                respiration = (float)Convert.ToDouble(words[2]);

                frontalAss = Mathf.Log(alphaRight) - Mathf.Log(alphaLeft);

                Debug.Log("Breathing value: " + SensorData.RespOut);


                if (frontalAss < faMin)
                {
                    faMin = frontalAss;
                }


                if (frontalAss > faMax)
                {
                    faMax = frontalAss;
                }

                faRange = Math.Max(faMax - faMin, 0.1f);
                //faRange = faMax - faMin + 0.1f;


                Debug.Log(" Toimii kuin junan vessa");

                Debug.Log("faMin: " + faMin);
                Debug.Log("faMax: " + faMax);
                Debug.Log("frontalAss: " + frontalAss);
                Debug.Log("faRange: " + faRange);

                if (initSteps > 0)
                {
                    SensorData.RespOut = 0;
                    SensorData.FAOut = 0;
                }
                else
                {

                    //check that we give out reasonable numbers)
                    float faOutTemp = (frontalAss - faMin) / faRange;
                    if (float.IsNaN(faOutTemp))
                    {
                        faOutTemp = 0.0f;
                    }

                    SensorData.FAOut = faOutTemp;
                    SensorData.RespOut = respiration - prevRespiration;
                }

                if (initSteps == 1)
                {
                    faRange = Math.Max(faMax - faMin, 0.1f);
                    prevRespiration = respiration;
                    Debug.Log("AlphaRange: " + faRange);
                    Debug.Log("BaselineLength: " + initSteps);
                }
                if (initSteps > 0)
                {
                    initSteps--;
                }
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

            Debug.Log("input from server " + stringData);
            Debug.Log("frontal A$$ " + frontalAss);
        }
        //myClient.Close();
        //     Console.WriteLine("Disconnecting...");
        //     myListener.Shutdown(SocketShutdown.Both);
        //    myListener.Close();
    }
    ~TCPClientThreadFA()
    {
        myClient.Close();
    }
}
