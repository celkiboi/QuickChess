using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
    static extern int SendData(IntPtr socket, byte[] data, int length);

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

    public int SendData(byte[] data)
    {
        int bytesSent = SendData(socket, data, data.Length);

        return bytesSent;
    }

    public async Task<byte[]> ReceiveData()
    {
        byte[] buffer = new byte[1024];
        int bytesReceived = await Task.Run(() =>
        {
            return ReceiveData(socket, buffer, buffer.Length);
        });

        return buffer;
    }
}
