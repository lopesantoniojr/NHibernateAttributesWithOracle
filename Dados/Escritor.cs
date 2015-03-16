using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using CsvHelper;
using NHibernate;

namespace Dados
{
    public class Escritor
    {
        public static void CriarArquivoCNARH()
        {
            string caminhoArquivo = ConfigurationManager.AppSettings["CaminhoParaSalvarArquivo"] + "CNARH_TELAS1E2_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            string delimitador = ConfigurationManager.AppSettings["Delimitador"];
            int chaveCategoria = Convert.ToInt32(ConfigurationManager.AppSettings["ChaveCategoria"]);

            IList<Entidades.TramInformacoes> tramInformacoes = new List<Entidades.TramInformacoes>();
            IList<Entidades.TramInformacoesProcessos> tramInformacoesProcessos = new List<Entidades.TramInformacoesProcessos>();

            using (ISession session = NHibernateSession.OpenSession())
            {
                tramInformacoes = session.QueryOver<Entidades.TramInformacoes>()
                                             .Where(x => x.CdChaveCategoria == chaveCategoria)
                                             .And(x => x.CdTipoInformacao == "C" || x.CdTipoInformacao == "A")
                                             .OrderBy(x => x.DeObservacao).Asc
                                             .List<Entidades.TramInformacoes>();
            }

            using (var w = new CsvWriter(new StreamWriter(caminhoArquivo, false, Encoding.UTF8)))
            {
                string conteudo = string.Empty;
                w.Configuration.Delimiter = delimitador;

                for (int i = 0; i < tramInformacoes.Count; i++)
                {
                    w.WriteField(tramInformacoes[i].DeInformacao);

                    using (ISession session = NHibernateSession.OpenSession())
                    {
                        tramInformacoesProcessos = session.QueryOver<Entidades.TramInformacoesProcessos>()
                                                     .Where(x => x.CdChaveCategoria == chaveCategoria)
                                                     .And(x => x.CdChaveInformacao == tramInformacoes[i].CdChaveInformacao)
                                                     .OrderBy(x => x.DtCriacao).Desc    
                                                     .List<Entidades.TramInformacoesProcessos>();
                    }

                    conteudo += tramInformacoesProcessos[0].DeValor + delimitador;
                }

                w.NextRecord();
                w.WriteField(conteudo.Remove(conteudo.Length - 1, 1), false);
                w.NextRecord();
            }
        }
    }
}
