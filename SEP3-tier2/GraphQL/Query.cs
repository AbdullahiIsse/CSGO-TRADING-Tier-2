using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using SEP3_tier2.Data;
using SEP3_tier2.Models;

namespace SEP3_tier2.GraphQL
{
    public class Query
    {
        
        
        [UseFiltering]
        [UseSorting]
        
        public  Task<IList<userAccount>> GetUsers([Service] IWeaponData context)
        {
            
            return  context.getAllWeapons();
        }
        
    }
}