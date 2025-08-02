using AutoMapper;
using Web.Business.Mapping.Maps;

namespace Web.Business.Mapping
{
    public static class MapperHelper
    {
        public static List<Profile> SettingUp()
        {
            return new List<Profile>() { 
                new ContractProfile(),
            };
        }
    }
}
