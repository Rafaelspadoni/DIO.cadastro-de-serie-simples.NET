using System;

namespace DIO.Series
{
    //Atributos
    public class Series : EntidadeBase
    {

        private Genero Genero { get; set;}

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

        //Metodos 
        public Series(int id, Genero genero, string titulo, string descricao, int ano) 
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano;
            return retorno; 
        }

        public string retornoTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}