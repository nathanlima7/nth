using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicação_para_oçamento
{
    public partial class Form1 : Form{
        double agregado, trelicaPilar, trelicaCinta, trelicaTotal;
        double soma, comprimento, largura, altura, areaMuro;
        double bloco, cimentoTotal, cimentoBloco, cimentoConcreto;
        double cimentoB, cimentoC;
        double areiaBloco, areiaConcreto, areiaTotal;

        public Form1(){
            InitializeComponent();
        }

        private void btCalc_Click(object sender, EventArgs e){
            comprimento = double.Parse(tbComprimento.Text);
            largura = double.Parse(tbLargura.Text);
            altura = double.Parse(tbAltura.Text);

            //calcula a área do muro em m²
            soma = (comprimento + largura) * 2;            
            areaMuro = soma * altura;

            //calcula a quantidade total de blocos 
            bloco = areaMuro * 32;
            lbBlocos.Text = Convert.ToString(Math.Ceiling(bloco));

            //calcula a quantidade de areia para a parede, para as estruturas de concreto e o total
            areiaBloco = (areaMuro * 40.5) / 27;
            areiaConcreto = (soma * 0.0168 * 1000) / 18;
            areiaTotal = areiaBloco + areiaConcreto;
            lbAreia.Text = Convert.ToString(Math.Ceiling(areiaTotal));

            //calcula a quantidade de cimento para a parede, para as estruturas de concreto e o total
            cimentoB = (areaMuro * 27) / 8;
            cimentoBloco = cimentoB / 50;
            cimentoC = (areiaConcreto * 27) / 4;
            cimentoConcreto = cimentoC / 50;
            cimentoTotal = cimentoBloco + cimentoConcreto;
            lbCimento.Text = Convert.ToString(Math.Ceiling(cimentoTotal));

            //calcula a quantidade de agregado para as estruturas de concreto
            agregado = areiaConcreto;
            lbAgregado.Text = Convert.ToString(Math.Ceiling(agregado));

            //calcula a quantidade de treliças para o radier
            trelicaPilar = soma / 2.5;
            trelicaCinta = soma / 3;
            trelicaTotal = trelicaPilar + trelicaCinta;
            lbRadier.Text = Convert.ToString(Math.Ceiling(trelicaTotal));            
        }

        private void btLimpar_Click(object sender, EventArgs e){
            tbComprimento.Clear();
            tbLargura.Clear();
            tbAltura.Clear();
        }

        private void btCalcular_Click(object sender, EventArgs e){

            double cimColunas, cimMuro, cimTotal, areiaBloc, areiaColun, areiaColuna, areiaTot, bloc, trelic;

            comprimento = double.Parse(tbCompr.Text);
            largura = double.Parse(tbLarg.Text);
            altura = double.Parse(tbAlt.Text);

            soma = (comprimento + largura) * 2;
            areaMuro = soma * altura;

            //Quantidade de tijolos
            bloc = areaMuro * 32;
            lbBloc.Text = Convert.ToString(Math.Ceiling(bloc));

            //Quantidade de treliças para as colunas
            trelic = soma / 2.5;
            lbTreli.Text = Convert.ToString(Math.Ceiling(trelic));            
            
            //Cimento para a parede e as colunas
            cimColunas = (soma / 2.5) * 0.324;
            cimMuro = (areaMuro * 27) / 8;
            cimTotal = (cimColunas + cimMuro) / 50;
            lbCim.Text = Convert.ToString(Math.Ceiling(cimTotal));

            //Areia para a parede e as colunas
            areiaBloc = (areaMuro * 40.5) / 27;
            areiaColun = (soma / 2.5) * 0.0504;
            areiaColuna = areiaColun * 1000;
            areiaTot = (areiaBloc + areiaColuna) / 18;
            lbAre.Text = Convert.ToString(Math.Ceiling(areiaTot));
        }
    }
}