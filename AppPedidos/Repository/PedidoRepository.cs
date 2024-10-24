using AppPedidos.Context;
using AppPedidos.Models;
using AppPedidos.Repository.Interface;
using AppPedidos.ViewModel;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AppPedidos.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _AppDbContext;

        public PedidoRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public bool EnviarEMail(ItensEnvioViewModel model, int numeroPedido, DateTime dataProcedimento)
        {

            IEnumerable<EmailEnvioModel> emailsEnvio = _AppDbContext.EmailEnvio.Where(e => e.RoleId == 1);


            string smtpAdress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            bool allEmailSend = true;

            string emailFrom = "tiago.figueiredo058@gmail.com";
            string password = "qviq cbxu pamx slns";
            string assunto = $"Pedido {numeroPedido}";
            string body = CorpoEMail(model, dataProcedimento);

            foreach (var email in emailsEnvio)
            {

                string emailTo = email.Email;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom, "Tiago de Paula Figueiredo Oliveira");
                    mail.To.Add(emailTo);
                    mail.Subject = assunto;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtpAdress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        try
                        {
                            smtp.Send(mail);
                        }
                        catch
                        {
                            allEmailSend = false;
                        }
                    }


                }

            }

            return allEmailSend;

        }

        public string CorpoEMail(ItensEnvioViewModel model, DateTime dataProcedimento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<p><strong>Paciente: </strong>{model.PacienteSelecionado.NomePaciente}</p>");
            sb.AppendLine($"<p><strong>Hospital: </strong>{model.HospitalSelecionado.NomeHospital}</p>");
            sb.AppendLine($"<p><strong>Convênio: </strong>{model.ConvenioSelecionado.NomeConvenio}</p>");

            if (dataProcedimento != new DateTime(1, 1, 1))
            {
                sb.AppendLine($"<p><strong>Data da cirugia: </strong>{dataProcedimento.ToString("dd/MM/yyyy")}</p>");
                sb.AppendLine($"<p><strong>Hora da cirugia: </strong>{dataProcedimento.ToString("HH:mm:ss")} </p>");
            }
            sb.AppendLine($"<p><strong>Observações: </strong>{model.Observacoes}</p>");

            //tabela com os itens
            sb.AppendLine($"<table border = '1' style='width: 100%'; border-collapse: collapse;>");
            sb.AppendLine("<tr>");
            sb.AppendLine($"<th style='padding: 8px; text-align: center;'>Referência</th>");
            sb.AppendLine($"<th style='padding: 8px; text-align: center;'>Descrição</th>");
            sb.AppendLine($"<th style='padding: 8px; text-align: center;'>Quantidade</th>");
            sb.AppendLine("</tr>");

            foreach (var produtos in model.ProdutoSelecionados)
            {
                if (produtos.Quantidade > 0)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td style='padding=8px; text-align:center;'>{produtos.CodigoProduto}</td>");
                    sb.AppendLine($"<td style='padding=8px; text-align:center;'>{produtos.DescricaoProduto}</td>");
                    sb.AppendLine($"<td style='padding=8px; text-align:center;'>{produtos.Quantidade}</td>");
                    sb.AppendLine("</tr>");
                }
            }

            sb.AppendLine("</table>");

            return sb.ToString();

        }

        public int EnviarPedido(ItensEnvioViewModel model)
        {
            //TRATANDO NULOS
            model.Observacoes = String.IsNullOrEmpty(model.Observacoes) ? "Não possui" : model.Observacoes;
            model.HoraProcedimento = String.IsNullOrEmpty(model.HoraProcedimento) ? "00:00:00" : model.HoraProcedimento;
            model.DataProcedimento = String.IsNullOrEmpty(model.DataProcedimento) ? "01/01/0001" : model.DataProcedimento;

            var pedido = new Pedido()
            {
                DataProcedimento = Convert.ToDateTime(model.HoraProcedimento + " " + model.DataProcedimento),
                HospitalId = model.HospitalSelecionado.HospitalId,
                MedicosId = model.MedicoSelecionado.MedicoId,
                ConvenioId = model.ConvenioSelecionado.ConvenioId,
                PacienteId = model.PacienteSelecionado.PacienteId,
                DataPedido = DateTime.Today,
                Emergencial = model.Emergencial,
                Observações = model.Observacoes,
                UsuarioId = 1,
                PedidosItens = new List<PedidosItens>()
            };

            foreach (var produto in model.ProdutoSelecionados.Where(p => p.Quantidade >= 1))
            {
                pedido.PedidosItens.Add(new PedidosItens
                {
                    ProdutosId = produto.ProdutoId,
                    Quantidade = produto.Quantidade,
                });
            }

            _AppDbContext.Pedido.Add(pedido);
            _AppDbContext.SaveChanges();

            var numeroPedido = pedido.PedidoId;
            DateTime dataParaEmail = pedido.DataProcedimento ?? new DateTime(1, 1, 1);

            EnviarEMail(model, numeroPedido, dataParaEmail);

            if (numeroPedido > 0)

            {
                return numeroPedido;
            }
            else
            {
                return numeroPedido = 0;
            }
        }
    }
}
