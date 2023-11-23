using System;
using System.Collections.Generic;

class Computer
{
    public string IPAddress { get; set; } = "";
    public int Power { get; set; }
    public string OS { get; set; } = "";
}

class Server : Computer, IConnectable
{
    public int StorageCapacity { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to computer with IP address: {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from computer with IP address: {target.IPAddress}");
    }

    public void SendData(Computer target, string data)
    {
        Console.WriteLine($"Data sent to computer with IP address {target.IPAddress}: {data}");
    }

    public void ReceiveData(Computer source, string data)
    {
        Console.WriteLine($"Data received from computer with IP address {source.IPAddress}: {data}");
    }
}

class Workstation : Computer, IConnectable
{
    public string Department { get; set; } = "";

    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to computer with IP address: {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from computer with IP address: {target.IPAddress}");
    }

    public void SendData(Computer target, string data)
    {
        Console.WriteLine($"Data sent to computer with IP address {target.IPAddress}: {data}");
    }

    public void ReceiveData(Computer source, string data)
    {
        Console.WriteLine($"Data received from computer with IP address {source.IPAddress}: {data}");
    }
}

class Router : Computer, IConnectable
{
    public string Gateway { get; set; } = "";
    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to computer with IP address: {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from computer with IP address: {target.IPAddress}");
    }

    public void SendData(Computer target, string data)
    {
        Console.WriteLine($"Data sent to computer with IP address {target.IPAddress}: {data}");
    }

    public void ReceiveData(Computer source, string data)
    {
        Console.WriteLine($"Data received from computer with IP address {source.IPAddress}: {data}");
    }
}

interface IConnectable
{
    void Connect(Computer target);
    void Disconnect(Computer target);
    void SendData(Computer target, string data);
    void ReceiveData(Computer source, string data);
}

class Network
{
    private List<Computer> computers;

    public Network()
    {
        computers = new List<Computer>();
    }

    public void AddComputer(Computer computer)
    {
        computers.Add(computer);
    }

    public void ConnectComputers(Computer computer1, Computer computer2)
    {
        if (computers.Contains(computer1) && computers.Contains(computer2))
        {
            if (computer1 is IConnectable connectable1)
            {
                connectable1.Connect(computer2);
            }

            if (computer2 is IConnectable connectable2)
            {
                connectable2.Connect(computer1);
            }
        }
        else
        {
            Console.WriteLine("Both computers should be part of the network to establish a connection.");
        }
    }

    public void DisconnectComputers(Computer computer1, Computer computer2)
    {
        if (computers.Contains(computer1) && computers.Contains(computer2))
        {
            if (computer1 is IConnectable connectable1)
            {
                connectable1.Disconnect(computer2);
            }

            if (computer2 is IConnectable connectable2)
            {
                connectable2.Disconnect(computer1);
            }
        }
        else
        {
            Console.WriteLine("Both computers should be part of the network to disconnect.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Server server = new Server { IPAddress = "192.168.1.1", Power = 100, OS = "Windows Server", StorageCapacity = 500 };
        Workstation workstation = new Workstation { IPAddress = "192.168.1.2", Power = 80, OS = "Windows 10", Department = "IT" };
        Router router = new Router { IPAddress = "192.168.1.3", Power = 90, OS = "RouterOS", Gateway = "192.168.1.1" };

        Network network = new Network();
        network.AddComputer(server);
        network.AddComputer(workstation);
        network.AddComputer(router);

        network.ConnectComputers(server, workstation);
        network.ConnectComputers(workstation, router);
        network.DisconnectComputers(server, workstation);
    }
}
