using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace ti89
{
    public class Banco
    {
        public static MySqlConnection Abrir()
        {
            string strConexao = @"server=localhost;Database=ti89;user id=root;password=usbw";
            MySqlConnection cn = new MySqlConnection(strConexao);
            cn.Open();
            return cn;
        }
    }
}
/*create database ti89;
use ti89;
create table cadastro(
id int auto_increment primary key,
nome varchar(50),
email varchar(100)
);

Criando Procedure
delimiter $$
	create procedure sp_InsertUpdate(
    _id int, _nome varchar(50),_email varchar(100),_acao int)
    begin

  
     if _acao = 1 then
        insert into cadastro(id, nome, email)
        values(null, _nome, _email);
select last_insert_id();
elseif _acao = 2 then
			update cadastro
				set  nome = _nome,
            email = _email
                    where id = _id;
end if;
end $$
    
    


delimiter */