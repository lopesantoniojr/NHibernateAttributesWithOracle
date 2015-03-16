using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping;
using NHibernate.Mapping.Attributes;

namespace Entidades
{
    [Class(Table = "TRAM_INFORMACOES_PROCESSOS", NameType = typeof(TramInformacoesProcessos))]
    public class TramInformacoesProcessos
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

        [Id(Name = "CdChaveInformacaoProcesso", Column = "CD_CHAVE_INFORMACAO_PROCESSO", TypeType = typeof(int)),
        Generator(1, Class = "sequence"),
        Param(2, Name = "sequence", Content = "GERHA.SQ_TRAMINFORMACOESPROC")]
        public virtual int CdChaveInformacaoProcesso { get; set; }

        [Property(Column = "DE_INFORMACAO")]
        public virtual string DeInformacao { get; set; }

        [Property(Column = "DE_VALOR")]
        public virtual string DeValor { get; set; }

        [Property(Column = "CD_SIGLA_UNIDADE")]
        public virtual string CdSiglaUnidade { get; set; }

        [Property(Column = "CD_CHAVE_INFORMACAO")]
        public virtual int CdChaveInformacao { get; set; }

        [Property(Column = "CD_CHAVE_PROCESSO")]
        public virtual int CdChaveProcesso { get; set; }

        [Property(Column = "CD_CHAVE_SERVICO")]
        public virtual int CdChaveServico { get; set; }

        [Property(Column = "CD_CHAVE_CATEGORIA")]
        public virtual int CdChaveCategoria { get; set; }
    }
}
