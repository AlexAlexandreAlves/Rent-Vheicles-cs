using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controller
{
    public static class Cliente
    {
        public static Model.Cliente CriarCliente(
            string Nome,
            string DtNascimento,
            string Cpf,
            string DiasParaRetorno)
        {


            Regex rgx = new Regex("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$");
            if (!rgx.IsMatch(Cpf))
            {
                throw new Exception("C.P.F. Inválido");
            }

            DateTime Data;


            try
            {
                Data = Convert.ToDateTime(DtNascimento);
            }
            catch
            {
                throw new Exception("Data de nascimento inválida");
            }

            return new Model.Cliente(
                 Nome,
                 Data,
                 Cpf,
                 Convert.ToInt32(DiasParaRetorno)
             );
        }

        public static Model.Cliente AtualizarClientes(
            Model.Cliente cliente,
            string stringCampo,
            string stringValor
        )
        {
            int Campo = Convert.ToInt32(stringCampo);
            switch (Campo)
            {
                case 1: //Nome;
                    break;
                case 2: //CPF;
                    break;

                    Regex rgx = new Regex("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$");
                    if (!rgx.IsMatch(Cpf))
                    {
                        throw new Exception("C.P.F. Inválido");
                    }
                    break;
            }
        }

        public static void RemoverClientes(string StringId)
        {
            int Id = Convert.ToInt32(StringId);
            try
            {
                Model.Cliente.RemoverClientes(Id);
            }
            catch
            {
                throw new Exception("Não foi permitido concluir a exclusão ou ID inválido ");
            }
        }

        public static IEnumerable<Model.Cliente> ListarClientes()
        {
            return Model.Cliente.GetClientes();
        }

        public static Model.Cliente GetCliente(string StringId)
        {
            int Id = Convert.ToInt32(StringId);
            int ListLenght = Model.Cliente.GetCount();

            if (Id < 0 || ListLenght <= Id)
            {
                throw new Exception("Id informado é inválido.");
            }

            return Model.Cliente.GetCliente(Id);
        }


    }
}
