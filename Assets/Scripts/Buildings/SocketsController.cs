using Events;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;

public class SocketsController : Singleton<SocketsController>
{
    [SerializeField]
    private List<BuildingSocket> sockets = new List<BuildingSocket> ();

    public void BlockSockets()
    {
        foreach(BuildingSocket socket in sockets)
        {
            socket.BlockSocket = true;
        }
    }

    public void UnblockSockets()
    {
        foreach (BuildingSocket socket in sockets)
        {
            socket.BlockSocket = false;
        }
    }

    public void BlockSocketsExcept(BuildingSocket exceptionSocket)
    {
        foreach (BuildingSocket socket in sockets)
        {
            if (exceptionSocket == socket)
                continue;
            socket.BlockSocket = true;
        }
    }

    public void UnlockOneSocket(BuildingSocket exceptionSocket)
    {
        exceptionSocket.BlockSocket = false;
    }
}


