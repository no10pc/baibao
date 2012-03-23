﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Linq;
using System.Text;
namespace baibal.Common
{
    public class MyIPAddress
    {
        Action<IPAddress> FoundCallback;
        UdpAnySourceMulticastClient MulticastSocket;
        const int PortNumber = 50000;
        // pick a number, any number
        string MulticastMessage = "FIND-MY-IP-PLEASE" + new Random().Next().ToString();
        public void Find(Action<IPAddress> callback)
        {
            FoundCallback = callback;
            MulticastSocket = new UdpAnySourceMulticastClient(IPAddress.Parse("239.255.255.250"), PortNumber);
            MulticastSocket.BeginJoinGroup((result) =>
            {
                try
                {
                    MulticastSocket.EndJoinGroup(result);
                    GroupJoined(result);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("EndjoinGroup exception {0}", ex.Message);
                    // This can happen eg when wifi is off 
                    FoundCallback(null);
                }
            }, null);
        }
        void callback_send(IAsyncResult result)
        { }
        byte[] MulticastData;
        bool keepsearching;
        void GroupJoined(IAsyncResult result)
        {
            MulticastData = Encoding.UTF8.GetBytes(MulticastMessage);
            keepsearching = true;
            MulticastSocket.BeginSendToGroup(MulticastData, 0, MulticastData.Length, callback_send, null);
            while (keepsearching)
            {
                try
                {
                    byte[] buffer = new byte[MulticastData.Length];
                    MulticastSocket.BeginReceiveFromGroup(buffer, 0, buffer.Length, DoneReceiveFromGroup, buffer);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Stopped Group read due to " + ex.Message); keepsearching = false;
                }
            }
        }
        void DoneReceiveFromGroup(IAsyncResult result)
        {
            IPEndPoint where;
            int responselength = MulticastSocket.EndReceiveFromGroup(result, out where);
            byte[] buffer = result.AsyncState as byte[];
            if (responselength == MulticastData.Length && buffer.SequenceEqual(MulticastData))
            {
                Debug.WriteLine("FOUND myself at " + where.Address.ToString());
                keepsearching = false;
                FoundCallback(where.Address);
            }
        }
    }
}
