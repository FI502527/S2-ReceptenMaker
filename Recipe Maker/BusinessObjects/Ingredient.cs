using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Ingredient
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public void SetId(int id)
        {
            Id = id;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public void SetInfo(int id, string name, string description)
        {
            Id = id;
            Name = name;
            if(description != null)
            {
                Description = description;
            }
        }
        public bool DescriptionCheck()
        {
            if (string.IsNullOrEmpty(Description))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
