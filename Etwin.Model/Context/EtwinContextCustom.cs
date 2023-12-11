using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Etwin.Model.Context
{
    public partial class EtwinContextCustom  //: ETwinContext
    {
    //    private string ConnectionString = String.Empty;

    //    //public EtwinContextCustom(string cs) : base(GetOptions(cs))
    //    //{
    //    //    ConnectionString = cs;
    //    //}

    //    private static DbContextOptions<EtwinContextCustom> GetOptions(string connectionString)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<EtwinContextCustom>();
    //        optionsBuilder.UseSqlServer(connectionString); 

    //        return optionsBuilder.Options;
    //    }

    //    private string GetConnectionString()
    //    {
    //        string cs = string.Empty;
    //        var builder = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    //        IConfiguration _configuration = builder.Build();
    //        if (!string.IsNullOrEmpty(_configuration.GetConnectionString("MbkDbConstr")))
    //        {
    //            cs = _configuration.GetConnectionString("MbkDbConstr");
    //        }
    //        return cs;
    //    }
    }

}
