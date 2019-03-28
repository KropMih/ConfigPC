using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConfigPC
{
    class ComponentsContext : DbContext
    {
        public ComponentsContext() : base("DBConnection") { }
        public DbSet<AudioCard> AudioCards { get; set; }
        public DbSet<AudioCardType> AudioCardTypes { get; set; }
        public DbSet<AudioChannel> AudioChannels { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CasePlace> CasePlaces { get; set; }
        public DbSet<Chipset> Chipsets { get; set; }
        public DbSet<CodeName> CodeNames { get; set; }
        public DbSet<Cooler> Coolers { get; set; }
        public DbSet<CoolerCompatibility> CoolerCompatibilities { get; set; }
        public DbSet<CoolerType> CoolerTypes { get; set; }
        public DbSet<DirectXVersion> DirectXVersions { get; set; }
        public DbSet<DriveType> DriveTypes { get; set; }
        public DbSet<FormFactorC> FormFactorsC { get; set; }
        public DbSet<FormFactorD> FormFactorsD { get; set; }
        public DbSet<FormFactorHD> FormFactorsHD { get; set; }
        public DbSet<FormFactorM> FormFactorsM { get; set; }
        public DbSet<FormFactorMB> FormFactorsMB { get; set; }
        public DbSet<FormFactorPB> FormFactorsPB { get; set; }
        public DbSet<GPUModel> GPUModels { get; set; }
        public DbSet<HardDrive> HardDrives { get; set; }
        public DbSet<HDMemoryType> HDMemoryTypes { get; set; }
        public DbSet<MemoryType> MemoryTypes { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<OpenGLVersion> OpenGLVersions { get; set; }
        public DbSet<PowerBlock> PowerBlocks { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<Socket> Sockets { get; set; }
        public DbSet<SSDDrive> SSDDrives { get; set; }
        public DbSet<Videocard> Videocards { get; set; }
}
}
