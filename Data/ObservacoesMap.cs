using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Api.Data
{
    public class ObservacoesMap : IEntityTypeConfiguration<ObservacoesModel>
    {
        public void Configure(EntityTypeBuilder<ObservacoesModel> builder)
        {
            builder.HasKey(x => x.ObservacoesId);
            builder.Property(x => x.ObservacoesDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacoesLocal).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacoesData).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimaisId);
            builder.Property(x => x.UsuarioId);

        }
    }
}
