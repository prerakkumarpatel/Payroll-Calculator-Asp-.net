using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll_Calculator.Models;

    public class WorkerContext : DbContext
    {
        public WorkerContext (DbContextOptions<WorkerContext> options)
            : base(options)
        {
        }

        public DbSet<Payroll_Calculator.Models.PieceworkWorkerModel> PieceworkWorkerModel { get; set; } = default!;
    }
