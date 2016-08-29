using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Imposto.Core.Domain;
using Imposto.Core.Service;
using TesteImposto.Properties;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        #region Construtor

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = ObterTablePedidos();
            ResizeColumns();
            CarregarComboEstados();
        }

        #endregion

        #region Eventos

        private void dataGridViewPedidos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewPedidos.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                    tb.KeyPress += Control_KeyPress;
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                new NotaFiscalService().GerarNotaFiscal(ObterPedido());
                LimparCampos();
                MessageBox.Show(Resources.OperacaoEfetuadaComSucesso);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void LimparCampos()
        {
            textBoxNomeCliente.Text = string.Empty;
            cboEstadoDestino.SelectedIndex = -1;
            cboEstadoOrigem.SelectedIndex = -1;
            dataGridViewPedidos.DataSource = ObterTablePedidos();
        }

        #endregion

        #region Métodos

        private Pedido ObterPedido()
        {
            ValidarCamposPedido();

            Pedido pedido = new Pedido
            {
                EstadoOrigem = cboEstadoOrigem.SelectedValue.ToString(),
                EstadoDestino = cboEstadoDestino.SelectedValue.ToString(),
                NomeCliente = textBoxNomeCliente.Text,
                ItensDoPedido = ObterItensPedido()
            };

            return pedido;
        }

        private List<PedidoItem> ObterItensPedido()
        {
            List<PedidoItem> itensDoPedido = new List<PedidoItem>();

            DataTable table = (DataTable)dataGridViewPedidos.DataSource;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                ValidarItensPedido(row, i);

                itensDoPedido.Add(
                         new PedidoItem
                         {
                             Brinde = row[Resources.Brinde] != DBNull.Value && Convert.ToBoolean(row[Resources.Brinde]),
                             CodigoProduto = row[Resources.CodigoProduto].ToString(),
                             NomeProduto = row[Resources.NomeProduto].ToString(),
                             ValorItemPedido = Convert.ToDouble(row[Resources.Valor].ToString())
                         });
            }

            return itensDoPedido;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRow"></param>
        /// <param name="pIndice"></param>
        private void ValidarItensPedido(DataRow pRow, int pIndice)
        {
            if (string.IsNullOrEmpty(pRow[Resources.CodigoProduto].ToString()))
                throw new Exception(string.Format(Resources.CampoCodigoProdutoBranco, pIndice));

            if (string.IsNullOrEmpty(pRow[Resources.NomeProduto].ToString()))
                throw new Exception(string.Format(Resources.CampoNomeProdutoBranco, pIndice));

            if (string.IsNullOrEmpty(pRow[Resources.Valor].ToString()))
                throw new Exception(string.Format(Resources.CampoValorProdutoBranco, pIndice));
        }

        /// <summary>
        /// Efetua a validação da tela
        /// </summary>
        /// <returns></returns>
        private void ValidarCamposPedido()
        {
            if (string.IsNullOrEmpty(textBoxNomeCliente.Text))
                throw new Exception(Resources.NomeBranco);

            if (cboEstadoDestino.SelectedIndex == -1)
                throw new Exception(Resources.SelecioneEstadoDestino);

            if (cboEstadoOrigem.SelectedIndex == -1)
                throw new Exception(Resources.SelecioneEstadoOrigem);

            if (dataGridViewPedidos.RowCount < 2)
                throw new Exception(Resources.GridVazio);
        }

        private void ResizeColumns()
        {
            if (dataGridViewPedidos == null)
                return;

            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }
        }

        private object ObterTablePedidos()
        {
            DataTable table = new DataTable(Resources.Pedidos);
            table.Columns.Add(new DataColumn(Resources.NomeProduto, typeof(string)));
            table.Columns.Add(new DataColumn(Resources.CodigoProduto, typeof(string)));
            table.Columns.Add(new DataColumn(Resources.Valor, typeof(decimal)));
            table.Columns.Add(new DataColumn(Resources.Brinde, typeof(bool)));

            return table;
        }

        /// <summary>
        /// Carrego os combos de Estados da tela
        /// </summary>
        private void CarregarComboEstados()
        {
            cboEstadoOrigem.DataSource = Enum.GetValues(typeof(Enums.EstadosBrasil));   
            cboEstadoDestino.DataSource = Enum.GetValues(typeof(Enums.EstadosBrasil));
        }

        #endregion
    }
}