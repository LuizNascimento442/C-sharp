using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;
        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();


            comboEc.Items.Add("Casado");
            comboEc.Items.Add("Solteiro");
            comboEc.Items.Add("Viuvo");
            comboEc.Items.Add("Separado");

            comboEc.SelectedIndex = 0;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome == TxtNome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

            if(TxtNome.Text == "")
            {
                MessageBox.Show("preencha o campo nome");
                TxtNome.Focus();
                return;
            }

            if (TxtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("preencha o campo telefone");
                TxtTelefone.Focus();
                return;
            }

            char sexo;

            if (radioM.Checked)
            {
                sexo = 'm';
            }else if (radioF.Checked)
            {
                sexo = 'f';
            }
            else
            {
                sexo = '0';

            }

            Pessoa p = new Pessoa();
            p.Nome = TxtNome.Text;
            p.DataNascimento = TxtData.Text;
            p.EstadoCivil = comboEc.SelectedItem.ToString();
            p.Telefone = TxtTelefone.Text;
            p.casaPropria = checkCasa.Checked;
            p.Veiculo = checkVeiculo.Checked;
            p.Sexo = sexo;

            if(index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = Lista.SelectedIndex;
            pessoas.RemoveAt(indice);
            Listar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            TxtNome.Text = "";
            TxtData.Text = "";
            comboEc.SelectedIndex = 0;
            TxtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            TxtNome.Focus();

        }

        private void Listar()
        {
            Lista.Items.Clear();

            foreach(Pessoa p in pessoas)
            {
                Lista.Items.Add(p.Nome);
            }
        }

        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = Lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            TxtNome.Text = p.Nome;
            TxtData.Text = p.DataNascimento;
            comboEc.SelectedItem = p.EstadoCivil;
            TxtTelefone.Text = p.Telefone;
            checkCasa.Checked = p.casaPropria;
            checkVeiculo.Checked = p.Veiculo;
            
            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;

            }


        }
    }
}
