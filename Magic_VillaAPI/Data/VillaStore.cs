using Magic_VillaAPI.Models.VillaDto;
using System.Diagnostics.Contracts;

namespace Magic_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
            {
                new VillaDTO{Id = 1, Name = "Pool View"},
                new VillaDTO{Id = 2, Name = "Beach View"}
            };
    }
}
