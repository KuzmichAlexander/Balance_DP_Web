using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public class DPContext : DbContext
    {
        public DbSet<RegistrationData> Users { get; set; }

        public DbSet<DPInputData> Inputs { get; set; }

        public DbSet<InputParametrsList1> InputIndicators { get; set; }
        public DbSet<InputParametrsList2> InputMaterials { get; set; }
        public DbSet<COCKsParamsPersent> COCKsParamsPersents { get; set; }
        public DbSet<CastIronElementsPercent> CastIronElementsPercents { get; set; }
        public DbSet<BlastFurnace> BlastFurnace { get; set; }
        public DbSet<BlastFurnaceGas> BlastFurnaceGases { get; set; }
        public DbSet<BlowingParams> BlowingParams { get; set; }
        public DbSet<Slag> Slags { get; set; }
        public DbSet<ZHRM> ZHRMs { get; set; }
        public DbSet<COCKsAsh> COCKsAshes { get; set; }
        public DbSet<COCKsComposition> COCKsCompositions { get; set; }
        public DbSet<Flus> Fluses { get; set; }
        public DbSet<MaterialConsuption> MaterialConsuptions { get; set; }
        public DbSet<FlusModels> FlusModels { get; set; }
        public DbSet<Flus> LimeStone { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BlastFurnace.db");
        }
    }
}