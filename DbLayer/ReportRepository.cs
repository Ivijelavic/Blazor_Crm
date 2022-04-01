using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace CrmExpert.DbLayer
{
    public class ReportRepository : IReportRepository
    {
        private readonly OrbisDbContext orbisDbContext;
        private readonly MRManagementContext mrContext;

        public ReportRepository(OrbisDbContext _orbisDbContext, MRManagementContext _mrContext)
        {
            this.orbisDbContext = _orbisDbContext;
            this.mrContext = _mrContext;
        }
    }
}
