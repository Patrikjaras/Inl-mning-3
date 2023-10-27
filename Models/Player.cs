using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inlämning_3.Models
{
   public class Player
    {
       public string Name { get; set; }
       public Player(string name)
        {
            Name = name;
        }
       
    }
}
