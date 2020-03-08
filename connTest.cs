using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

public class connTest
{
    //check for internet connection
    public static bool DeadInternet()
    {
        try
        {
            Ping myPing = new Ping();
            string host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            return false;
        }
        catch
        {
            return true;
        }
    }
    public int PingHost(string host)
    {
        // return statuses
        // code 10: ping success
        // code 11: timeout
        // code 12: ping exception
        // code 13: no interconnection found
        // code 14: failure for unknown reason
        // code 15: socket exception

        //get IP address stupid bullshit
        string hostName = Dns.GetHostName(); //retreive name of host
        string stringAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
        IPAddress address = System.Net.IPAddress.Parse(stringAddress);

        //set ping options, ttl 128
        PingOptions pingOptions = new PingOptions(128, true);

        //create new ping instance
        Ping ping = new Ping();

        //32 byte buffer (create empty)
        byte[] buffer = new byte[32];

        //first make sure we actually have internet
        if (DeadInternet())
        {
            return 13;
        }
        else //uh oh no internets
        {
            //ping 4 times, as windows standard
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    //send the ping 4 times to the host and record the returned data.
                    //The Send() method expects 4 items:
                    //1) The IPAddress we are pinging
                    //2) The timeout value
                    //3) A buffer (our byte array)
                    //4) PingOptions
                    PingReply pingReply = ping.Send(address, 1000, buffer, pingOptions);

                    //make sure reply isn't null
                    if (pingReply != null)
                    {
                        switch (pingReply.Status)
                        {
                            case IPStatus.Success:
                                return 10;
                            case IPStatus.TimedOut:
                                return 11;
                            default:
                                return 14;
                        }
                    }
                    else
                    {
                        return 14;
                    }
                }
                catch (PingException)
                {
                    return 12;
                }
                catch (SocketException)
                {
                    return 15;
                }
            }
        }
        return 14;
    }
}