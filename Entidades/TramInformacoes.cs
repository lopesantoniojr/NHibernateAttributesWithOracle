using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping;
using NHibernate.Mapping.Attributes;

namespace Entidades
{
    [Class(Table = "TRAM_INFORMACOES", NameType = typeof(TramInformacoes))]
    public class TramInformacoes
    {
        [Property(Column = "OBJECTID")]
        public virtual int ObjectId { get; set; }

        [Property(Column = "DT_CRIACAO")]
        public virtual DateTime DtCriacao { get; set; }

        [Property(Column = "DT_ALTERACAO")]
        public virtual DateTime DtAlteracao { get; set; }

        [Property(Column = "CD_USUARIO_CRIACAO")]
        public virtual string CdUsuarioCriacao { get; set; }

        [Property(Column = "CD_USUARIO_ALTERACAO")]
        public virtual int CdUsuarioAlteracao { get; set; }

        [Property(Column = "DE_OBSERVACAO")]
        public virtual string DeObservacao { get; set; }

        [Id(Name = "CdChaveInformacao", Column = "CD_CHAVE_INFORMACAO", TypeType = typeof(int)),
        Generator(1, Class = "sequence"),
        Param(2, Name = "sequence", Content = "GERHA.SQ_TRAMINFORMACOES")]
        public virtual int CdChaveInformacao { get; set; }

        [Property(Column = "DE_INFORMACAO")]
        public virtual string DeInformacao { get; set; }

        [Property(Column = "QT_TAMANHO")]
        public virtual int QtTamanho { get; set; }

        [Property(Column = "FL_INICIO_PROCESSO")]
        public virtual string FlInicioProcesso { get; set; }

        [Property(Column = "FL_FINALIZACAO")]
        public virtual string FlFinalizacao { get; set; }

        [Property(Column = "NU_DE")]
        public virtual double NuDe { get; set; }

        [Property(Column = "NU_ATE")]
        public virtual double NuAte { get; set; }

        [Property(Column = "DT_DE")]
        public virtual DateTime DtDe { get; set; }

        [Property(Column = "DT_ATE")]
        public virtual DateTime DtAte { get; set; }

        [Property(Column = "CD_CHAVE_FORMATO_INFORMACAO")]
        public virtual string CdChaveFormatoInformacao { get; set; }

        [Property(Column = "CD_CHAVE_SERVICO")]
        public virtual int CdChaveServico { get; set; }

        [Property(Column = "CD_CHAVE_CATEGORIA")]
        public virtual int CdChaveCategoria { get; set; }

        [Property(Column = "CD_TIPO_INFORMACAO")]
        public virtual string CdTipoInformacao { get; set; }

        [Bag(1, Name = "TramInformacoesProcessos", Lazy = CollectionLazy.True, Table = "GERHA.TRAM_INFORMACOES_PROCESSOS", Cascade = "Delete"),
         Key(2, Column = "CD_CHAVE_INFORMACAO"),
         OneToMany(3, Class = "Entidades.TramInformacoesProcessos")]
        public virtual IList<TramInformacoesProcessos> TramInformacoesProcessos { get; set; }
    }
}
