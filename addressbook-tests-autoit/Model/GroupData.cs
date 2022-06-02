using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public GroupData() 
        {
        
        }
        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return this.Name.Equals(other.Name);
        }
    }
}
