using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using System.Text;

public class Socket
{
    [DllImport("SocketLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int InitializeWinsock();

    [DllImport("SocketLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CleanupWinsock();

    [DllImport("SocketLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr CreateSocket();

    [DllImport("SocketLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern int Connect(IntPtr socket, string ip, int port);

    [DllImport("SocketLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern int SendData(IntPtr socket, string data, int length);

    [DllImport("SocketLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CloseSocket(IntPtr socket);

    [DllImport("SocketLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern int ReceiveData(IntPtr socket, byte[] buffer, int bufferSize);

    IntPtr socket;

    public Socket()
    {
        socket = CreateSocket();
    }

    ~Socket()
    {
        CloseSocket(socket);
    }

    public void Connect(string serverIP, int serverPort)
    {
        if (Connect(socket, serverIP, serverPort) != 0)
            throw new Exception("Cannot connect socket");

    }

    public int SendData(string data)
    {
        byte[] messageBytes = Encoding.UTF8.GetBytes(data);
        int bytesSent = SendData(socket, data, messageBytes.Length);

        return bytesSent;
    }

    public string ReceiveData(string data)
    {
        byte[] buffer = new byte[1024];
        int bytesReceived = ReceiveData(socket, buffer, buffer.Length);
        return Encoding.UTF8.GetString(buffer, 0, bytesReceived);

    }
}
