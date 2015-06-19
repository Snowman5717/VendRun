using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;

public class NetworkManager : MonoBehaviour
{
    string registeredGameName = "Fuck Bitches Get Money";
    private float requestLength = 3;
    HostData[] hosts = null;
    NetworkView networkview;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cameraRig;
    [SerializeField] GameObject mainCamera;
    

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        //networkview = GetComponent<NetworkView>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

        if (Network.isServer)
        {
            return;
        }

        if (Network.isClient)
        {
            return;
        }

        if (GUI.Button(new Rect(25, 25, 200, 30), "Start Server"))
        {
            StartServer();
        }

        if (GUI.Button(new Rect(25, 65, 200, 30), "Get Server List"))
        {
            StartCoroutine("GetServerList");
        }


        if (hosts != null && hosts.Length > 0)
        {
            if (GUI.Button(new Rect(25, 105, 200, 30), hosts[0].gameName))
            {
                print(Network.Connect(hosts[0]).ToString());
            }
        }


    }

    public IEnumerator GetServerList()
    {
        MasterServer.RequestHostList(registeredGameName);
        //float timeStarted = Time.time;
        float timeEnd = Time.time + requestLength;

        while (Time.time < timeEnd)
        {
            hosts = MasterServer.PollHostList();
            yield return new WaitForEndOfFrame();
        }
    }

    private void StartServer()
    {
        Network.InitializeServer(16, 25002, false);
        MasterServer.RegisterHost(registeredGameName, "Vend Run", "Networking");
    }

    void OnServerInitialized()
    {
        SpawnPlayer();
        Debug.Log("Server Initialized");
    }

    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.RegistrationSucceeded)
        {
            print("Registration Successful");
        }
        else
        {
            print(msEvent.ToString());
        }
    }

    void OnConnectedToServer()
    {
        SpawnPlayer();
        print("OnConnectedToServer");
    }
    void OnDisconnectedFromServer(NetworkDisconnection dc)
    {
        print("OnDisconnectedFromServer--" + dc.ToString());
    }

    void FailedToConnect(NetworkConnectionError error)
    {
        print("FailedToConnect--" + error.ToString());
    }

    void FailedToConnectToMasterServer(NetworkConnectionError error)
    {
        print("FailedToConnectToMasterServer--" + error.ToString());
    }

    void OnNetworkInstantiate(NetworkMessageInfo info)
    {

        print("OnNetworkInstantiate--" + info.ToString());
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        //remove rpcs and destroy object
    }

    void OnApplicationQuit()
    {
        if (Network.isServer)
        {
            Network.Disconnect();
            MasterServer.UnregisterHost();
        }
    
    }

    private void SpawnPlayer()
    {
        GameObject playerTemp = Network.Instantiate(player, spawnPoint.position, Quaternion.identity, 0) as GameObject;
        playerTemp.GetComponent<Death>().spawn = spawnPoint.gameObject;
        
        GameObject cameraRigTemp = Instantiate(cameraRig, transform.position, Quaternion.identity) as GameObject;
        StartCoroutine(DelayedAssignment(playerTemp, cameraRigTemp));
        
    }

    IEnumerator DelayedAssignment(GameObject playerTemp, GameObject cameraRigTemp)
    {
        yield return new WaitForEndOfFrame();

        if (playerTemp.GetComponent<NetworkView>().isMine)
        {
            playerTemp.GetComponent<PlayerInput>().controlsEnabled = true;
        }

        if (cameraRigTemp.GetComponent<NetworkView>().isMine)
        {
            cameraRigTemp.SetActive(true);
            cameraRigTemp.GetComponent<FreeLookCam>().SetTarget(playerTemp.transform);
        }
    }
}
