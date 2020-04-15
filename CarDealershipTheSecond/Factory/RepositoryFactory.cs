using CarDealershipTheSecond.Data;
using CarDealershipTheSecond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CarDealershipTheSecond.Factory
{
    public class RepositoryFactory
    {
        public static IRepository Create()
        {
            string mode = WebConfigurationManager.AppSettings["repoMode"].ToString().ToLower();
            switch (mode)
            {
                case "qa":
                    return new QARepository();
                case "ado":
                    return new ADORepository();
                default:
                    throw new Exception("mode value in appSettings is not valid");
            }
        }
    }
}