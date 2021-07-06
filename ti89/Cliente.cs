using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ti89
{
     public class Cliente
    {
        //declaração de variaveis
        public int id;
        public string mensagem;
        public bool achou = false;

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        //CONSTRUTOR
        public Cliente() { }
        //alterar
        public Cliente(int nCodigo, string nNome, string nEmail)
        {
            this.ID = nCodigo;
            this.Nome = nNome;
            this.Email = nEmail;
        }
        //inserir
        public Cliente(string nNome, string nEmail)
        {

            this.Nome = nNome;
            this.Email = nEmail;
        }
        //metodo para inserir
        public void Inserir()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = Banco.Abrir();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "sp_InsertUpdate";
            comm.Parameters.AddWithValue("_id", 0);
            comm.Parameters.AddWithValue("_Nome", Nome);
            comm.Parameters.AddWithValue("_Email", Email);
            comm.Parameters.AddWithValue("_acao", MySqlDbType.Int32).Value = 1;
            comm.ExecuteNonQuery();
            mensagem = "Cadastro Realizado com Sucesso!";
            //retorno o auto_incremento
            comm = new MySqlCommand("select max(id) from Cadastro", Banco.Abrir());
            id = (int)comm.ExecuteScalar();

        }
        public void Alterar()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = Banco.Abrir();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "sp_InsertUpdate";
            comm.Parameters.AddWithValue("_id", ID);
            comm.Parameters.AddWithValue("_Nome", Nome);
            comm.Parameters.AddWithValue("_Email", Email);
            comm.Parameters.AddWithValue("_acao", MySqlDbType.Int32).Value = 2;
            comm.ExecuteNonQuery();
            mensagem = "Cadastro Alterado com Sucesso!";

        }
        public void Consultar(int _id)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = Banco.Abrir();
            comm.CommandText = " select * from cadastro where id =" + _id;
            MySqlDataReader dr = comm.ExecuteReader();

            //hasRows, teve retorno ou não

            if (!dr.HasRows)
            {
                mensagem = "Resgitro não encontrado";
                achou = false;
                return;
            }
            else
            {
                achou = true;
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    Nome = dr.GetString(1);
                    Email = dr.GetString(2);
                }
            }



        }
    }

}



    //metodo consultar
    