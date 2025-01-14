using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.UML2
{
    public class Pet : Animal, IIdentifiable
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Age { get; set; }
        public Owner Owner { get; set; }
        public PetInformation PetInfo { get; set; }

        public void Feed()
        {
            // Implementation
        }

        public bool IsHerbivore()
        {
            return !Carnivore;
        }
    }
}
