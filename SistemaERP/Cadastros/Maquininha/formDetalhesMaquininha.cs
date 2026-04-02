using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;

namespace SistemaERP.Cadastros.Maquininha
{
    public partial class formDetalhesMaquininha : Form
    {
        private int _id = 0;
        private MaquininhaEntity _maquininha;
        private readonly MaquininhaService _serviceMaquininha;
        private readonly ConfigAdquirenteService _serviceConfigAdquirente;

        public formDetalhesMaquininha(MaquininhaService service)
        {
            _serviceMaquininha = service;

            InitializeComponent();
            CarregarAdquirentes();
            CarregarTipoMaquininha();
            this.ConfiguraTabIndex();
        }

        public formDetalhesMaquininha(MaquininhaService service,int id) : this(service)
        {
            _id = id;
        }

        private void ConfigurarDataBinding()
        {
            _maquininha = _maquininha ?? new MaquininhaEntity();
            txtNome.DataBindings.Add(nameof(txtNome.Text), _maquininha, nameof(_maquininha.Nome));
            ckInativo.DataBindings.Add(nameof(ckInativo.Checked), _maquininha, nameof(_maquininha.Inativo));
            cbAdquirente.DataBindings.Add(nameof(cbAdquirente.SelectedValue), _maquininha, nameof(_maquininha.AdquirenteId));
            cbTipoMaquininha.DataBindings.Add(nameof(cbTipoMaquininha.SelectedValue), _maquininha, nameof(_maquininha.TipoMaquininha));
        }
        private void CarregarAdquirentes()
        {
            cbAdquirente.PreencherComboBoxList(
                _serviceConfigAdquirente.GetList().ToList(),
                nameof(ConfigAdquirenteEntity.Id),
                nameof(ConfigAdquirenteEntity.AdquirenteId)
                );
        }
        private void CarregarTipoMaquininha()
        {
            cbTipoMaquininha.PreencherComboBoxEnum<ETipoMaquininha>();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (_id == 0)
            {
                _maquininha.Id = _serviceMaquininha.Insert(_maquininha);
                _id = _maquininha.Id;
                this.Text = $"REGISTRO [{_maquininha.Id}]";
            }
            else
            {
                _serviceMaquininha.Update(_maquininha);
            }
            MessageBox.Show("Salvo com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formDetalhesMaquininha_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraMaquininha();

            ConfigurarDataBinding();
        }

        private void MostraMaquininha()
        {
            _maquininha = _serviceMaquininha.Get(_id);
            this.Text = $"REGISTRO [{_maquininha.Id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcMaquininha_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tcMaquininha.TabPages[e.Index];
            Rectangle tabBounds = tcMaquininha.GetTabRect(e.Index);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.TranslateTransform(tabBounds.Left + tabBounds.Width / 2, tabBounds.Top + tabBounds.Height / 2);

                g.DrawString(tabPage.Text, this.Font, SystemBrushes.ControlText, 0, 0, sf);

                g.ResetTransform(); // Reseta a rotação pra não afetar o resto
            }
        }
    }
}
