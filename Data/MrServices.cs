using CrmExpert.DbLayer;
using CrmExpert.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace CrmExpert.Data
{
    public class MrServices
    {
        private readonly MRManagementContext _context;
        public MrServices(MRManagementContext context)
        {
            _context = context;

        }
        //public List<string> GetVrstaArtiklaList()
        //{
        //    List<SCORING_Param1> scoringarams = new();

        //    scoringarams = _context.SCORING_Param1.ToList();

        //    List<string> vrstaopreme = scoringarams.Select(c => c.TipOpreme).Distinct().ToList();
        //    return vrstaopreme;
        //}
        //public string getBrand(int id)
        //{

        //    SCORING_Param1 ime = _context.SCORING_Param1.FirstOrDefault(x => x.id == id);
        //    return ime.Vendor;
        //}
        //public List<string> GetBrandsList(string vrOpreme)
        //{
        //    List<SCORING_Param1> scoringarams = new();

        //    scoringarams = _context.SCORING_Param1.Where(x => x.TipOpreme == vrOpreme).ToList();
        //    List<string> brands = scoringarams.Select(c => c.Vendor).Distinct().ToList();
        //    return brands;

        //}

    }
}
