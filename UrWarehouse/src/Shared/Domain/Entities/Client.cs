using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;


public class Client
{

    public required int ID { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public Client(int Id, string name, string lastname)
    {
        ID = Id;
        Name = name;
        LastName = lastname;

    }
}




