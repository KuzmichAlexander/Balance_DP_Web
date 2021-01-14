﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace balance_dp.Models
{
    public class DPContext : DbContext
    {
        public DbSet<DPInputData> Inputs {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BlastFurnace.db");
        }
    }
}
