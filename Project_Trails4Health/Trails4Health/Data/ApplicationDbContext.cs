using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* A seguir: 
 * - Criar Scaffolded Item:
 * Rck /controllers > add Scaffolded Item > MVC_controllers_with_views > Model Class: EX: "Trilho.cs"
 *      Notas: 1.Vai criar estrutura para CRUD de Trilho.cs - 2.Pode ser necessario > add Scaffolded Item (2x)
 */

// orig: namespace Trails4Health.Data
namespace Trails4Health.Models
{
    // class DbContext mapea BD
    // instancio esta classe na minha [EFRepository:IRepository] 
    public class ApplicationDbContext : DbContext
    {
        // base(options) mm que super: cria BD com as options
        // permite-me ter acessso ao que está no modelo
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // config. base dados com os modelos: digo como vou mapear a BD
        public DbSet<Trilho> Trilhos { get; set; }
        public DbSet<Dificuldade> Dificuldades { get; set; }
        public DbSet<EstadoTrilho> EstadoTrilhos { get; set; }
        public DbSet<Estado> Estados { get; set; }

        public DbSet<Questao> Questoes { get; set; }
        public DbSet<TipoQuestao> TipoQuestoes { get; set; }
        public DbSet<Turista> Turistas { get; set; }
        public DbSet<Guia> Guias { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Questionario> Questionarios { get; set; }
        public DbSet<QuestionarioQuestao> QuestionarioQuestoes { get; set; }
        //public DbSet<RespostaQuestionario> RespostaQuestionarios { get; set; }
        public DbSet<AvaliacaoGuia> AvaliacaoGuias { get; set; }
        public DbSet<AvaliacaoTrilho> AvaliacaoTrilhos { get; set; }
        public DbSet<Opcao> Opcoes { get; set; }

        //uso fluent API para enunciar explicitamente a relação
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // explicitar PK composta
            // EstadoTrilho tem PK constituida por: EstadoID TrilhoID
            // OLD:
            //modelBuilder.Entity<EstadoTrilho>()
            //    .HasKey(et => new { et.EstadoID, et.TrilhoID });

            modelBuilder.Entity<EstadoTrilho>()
                .HasKey(EstadoTrilho => EstadoTrilho.EstadoTrilhoID);

            // relação: EstadoTrilho - Estado
            // 1 EstadoTrilho tem 1 Estado; 1 Estado tem mts EstadoTrilhos; EstadoTrilho tem FK: EstadoID
            modelBuilder.Entity<EstadoTrilho>()
                .HasOne(EstadoTrilho => EstadoTrilho.Estado)
                .WithMany(Estado => Estado.EstadoTrilhos)
                .HasForeignKey(EstadoTrilho => EstadoTrilho.EstadoID);

            // relação: EstadoTrilho - Trilho
            // 1 EstadoTrilho tem 1 Trilho; 1 Trilho tem mts EstadoTrilhos; EstadoTrilho tem FK: TrilhoID
            modelBuilder.Entity<EstadoTrilho>()
                .HasOne(EstadoTrilho => EstadoTrilho.Trilho)
                .WithMany(Trilho => Trilho.EstadoTrilhos)
                .HasForeignKey(EstadoTrilho => EstadoTrilho.TrilhoID);

            // relação: Trilho - Dificuldade 
            // 1 Trilho tem 1 Dificuldade; 1 Dificuldade tem mts Trilhos; Trilho tem FK: DificuldadeID
            modelBuilder.Entity<Trilho>()
                .HasOne(Trilho => Trilho.Dificuldade)
                .WithMany(Dificuldade => Dificuldade.Trilhos)
                .HasForeignKey(Trilho => Trilho.DificuldadeID);

            //------------------------------------------------------
            modelBuilder.Entity<Questao>().HasKey(q => q.QuestaoID);
            modelBuilder.Entity<Questao>()
                .HasOne(q => q.TipoQuestao)
                .WithMany(tq => tq.Questoes)
                .HasForeignKey(q => q.TipoQuestaoID);

            modelBuilder.Entity<Turista>().HasKey(t => t.TuristaID);

            modelBuilder.Entity<Guia>().HasKey(g => g.GuiaID);

            //modelBuilder.Entity<RespostaQuestionario>().HasKey(rq => rq.RespostaQuestionarioID);

            modelBuilder.Entity<AvaliacaoGuia>().HasKey(ag => ag.AvaliacaoGuiaID);

            modelBuilder.Entity<AvaliacaoTrilho>().HasKey(at => at.AvaliacaoTrilhoID);

            modelBuilder.Entity<Questionario>().HasKey(qu => qu.QuestionarioID);

            modelBuilder.Entity<QuestionarioQuestao>().HasKey(qq => new { qq.QuestionarioID, qq.QuestaoID });
            modelBuilder.Entity<QuestionarioQuestao>()
                .HasOne(qq => qq.Questionario)
                .WithMany(qu => qu.QuestionarioQuestoes);
            modelBuilder.Entity<QuestionarioQuestao>()
                .HasOne(qq => qq.Questao)
                .WithMany(q => q.QuestionarioQuestoes);

            modelBuilder.Entity<TipoQuestao>().HasKey(tq => tq.TipoQuestaoID);

            modelBuilder.Entity<Resposta>().HasKey(r => new { r.OpcaoID, r.TuristaID });
            modelBuilder.Entity<Resposta>()
                .HasOne(r => r.Opcao)
                .WithMany(o => o.Respostas);
            //.OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Resposta>()
                .HasOne(r => r.Turista)
                .WithMany(t => t.Respostas);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Opcao>().HasKey(o => o.OpcaoID);
            modelBuilder.Entity<Opcao>()
                .HasOne(o => o.Questao)
                .WithMany(q => q.Opcoes)
                .HasForeignKey(o => o.QuestaoID);
        }
    }
}