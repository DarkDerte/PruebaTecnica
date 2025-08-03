using AutoMapper;
using Api.Business.Mapping.Maps;

namespace Api.Business.Mapping
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
