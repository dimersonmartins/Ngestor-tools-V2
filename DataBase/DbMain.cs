using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase
{
    public class DbMain
    {
        public DbMain(string managerConnectionString)
        {
            _managerConnectionString = managerConnectionString;
        }

        public const string dataBaseManager         = "Manager";
        private string _managerConnectionString = "";
        private int limit  = 50;
        public int countOs = 0;
        public async void execute()
        {
            try
            {
                AppCreateDB();
            }
            catch { }
        }
        private async void AppCreateDB()
        {
            if (!File.Exists(dataBaseManager))
            {
                SQLiteConnection.CreateFile(dataBaseManager);
                await AppCreateTable();
            }
        }
        private async Task<bool> AppCreateTable()
        {
            string[] tables = new string[]
            {
                "CREATE TABLE status (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(100))",

                "CREATE TABLE ngestor_dominios (id INTEGER PRIMARY KEY AUTOINCREMENT, dominio VARCHAR(255) UNIQUE)",
                "CREATE INDEX ngestor_dominios_indexs ON ngestor_dominios(id, dominio)",

                "CREATE TABLE users_servers (id INTEGER PRIMARY KEY AUTOINCREMENT, id_dominio_ngestor INTEGER, id_user_ngestor INTEGER, id_sistemas_tipo INTEGER, login VARCHAR(100), password VARCHAR(100))",
                "CREATE INDEX users_servers_indexs ON users_servers(id, login, password, id_dominio_ngestor, id_user_ngestor, id_sistemas_tipo)",

                "CREATE TABLE net_home (id INTEGER PRIMARY KEY AUTOINCREMENT, id_dominio_ngestor INTEGER, id_user_ngestor INTEGER, id_sistemas_tipo INTEGER, login VARCHAR(100), password VARCHAR(100))",
                "CREATE INDEX net_home_indexs ON net_home(id, login, password, id_dominio_ngestor, id_user_ngestor, id_sistemas_tipo)",

                "CREATE TABLE ordens_de_servicos (id INTEGER PRIMARY KEY AUTOINCREMENT, id_dominio_ngestor VARCHAR(150), id_sistemas_tipo INTEGER, numero_contrato VARCHAR(150), numero_os VARCHAR(150), tipo_servico VARCHAR(255), os TEXT)",
                "CREATE INDEX ordens_de_servicos_indexs ON ordens_de_servicos(numero_contrato, numero_os, id_dominio_ngestor, tipo_servico, id_sistemas_tipo)",

                "CREATE TABLE ngestor_users (id INTEGER PRIMARY KEY AUTOINCREMENT, id_dominio_ngestor INTEGER, id_user INTEGER, login VARCHAR(100) UNIQUE, password VARCHAR(100))",
                "CREATE INDEX ngestor_users_indexs ON ngestor_users(id, id_dominio_ngestor, id_user, login, password)",

                "CREATE TABLE ngestor_importacoes_automatica (id INTEGER PRIMARY KEY AUTOINCREMENT, id_dominio_ngestor INTEGER, id_user INTEGER, id_status INTEGER, id_sistemas_tipo INTEGER, total_os INTEGER,  data_importacao VARCHAR(100))",
                "CREATE INDEX ngestor_importacoes_automatica_indexs ON ngestor_importacoes_automatica(id, id_dominio_ngestor, id_user, id_status, id_sistemas_tipo)",

                "CREATE TABLE manager_config_timer (id INTEGER PRIMARY KEY AUTOINCREMENT, id_dominio_ngestor INTEGER, id_sistemas_tipo INTEGER, data_maxima INTEGER, timer INTEGER, active INTEGER)",

                "CREATE TABLE path_aplication (id INTEGER PRIMARY KEY AUTOINCREMENT, id_dominio_ngestor INTEGER, path VARCHAR(255))",
            };

            SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
            conexao.Open();
            try
            {
                for (int i = 0; i < tables.Count(); i++)
                {
                    SQLiteCommand command = new SQLiteCommand(tables[i], conexao);
                    command.ExecuteNonQuery();
                }
                tablesSeeders();
            }
            catch { conexao.Close(); }
            conexao.Close();
            return true;
        }
        private void tablesSeeders()
        {
            string[] seeders = new string[]
            {
                "INSERT INTO status (name) VALUES('CONCLUIDO')",
                "INSERT INTO status (name) VALUES('ERRO')",
            };

            SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
            conexao.Open();
            try
            {
                for (int i = 0; i < seeders.Count(); i++)
                {
                    SQLiteCommand command = new SQLiteCommand(seeders[i], conexao);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                conexao.Close();
            }
            conexao.Close();
        }
        public DataTable Query(string query)
        {
            try
            {
                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();
                SQLiteCommand command = new SQLiteCommand(query, conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable datatableDominios = new DataTable();
                da.Fill(datatableDominios);
                conexao.Close();
                return datatableDominios;
            }
            catch {
                return null;
            }
        }
        public void ExecuteSqlCommand(string query)
        {
            try
            {
                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();
                SQLiteCommand command = new SQLiteCommand(query, conexao);
                command.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {

            }
        }
        public DataTable paginate(int page, int id_dominio_ngestor, int id_sistemas_tipo)
        {
            try
            {
                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();

                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = {id_dominio_ngestor} AND id_sistemas_tipo = {id_sistemas_tipo} limit {limit} offset {page}", conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable datatable = new DataTable();
                da.Fill(datatable);

                SQLiteCommand countRows = new SQLiteCommand($"SELECT count(id_sistemas_tipo) FROM ordens_de_servicos WHERE id_dominio_ngestor = {id_dominio_ngestor} AND id_sistemas_tipo = {id_sistemas_tipo}", conexao);
                countRows.CommandType = CommandType.Text;

                countOs = Convert.ToInt32(countRows.ExecuteScalar());
                conexao.Close();
                return datatable;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<string> getFilters(int id_dominio_ngestor, int id_sistemas_tipo)
        {
            List<string> tipos_servico_f = new List<string>();
            SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
            conexao.Open();
            SQLiteCommand command = new SQLiteCommand($"SELECT tipo_servico FROM ordens_de_servicos WHERE id_dominio_ngestor = {id_dominio_ngestor} AND  id_sistemas_tipo = {id_sistemas_tipo}", conexao);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            tipos_servico_f.Clear();
            tipos_servico_f.Add("Todos");
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                if (!tipos_servico_f.Contains(datatable.Rows[i][0].ToString()))
                {
                    tipos_servico_f.Add(datatable.Rows[i][0].ToString());
                }
            }
            conexao.Close();
            return tipos_servico_f;
        }
        public DataTable SelectFromFilters(int id_dominio_ngestor, string os_selected_f, int id_sistemas_tipo)
        {
            if (os_selected_f == "Todos")
            {
               return selectAllSemPaginate(id_dominio_ngestor, id_sistemas_tipo);
            }

            try
            {
               
                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();

                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = '{id_dominio_ngestor}' AND id_sistemas_tipo = {id_sistemas_tipo} AND tipo_servico = '{os_selected_f}'", conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable datatable = new DataTable();
                da.Fill(datatable);
                return datatable;
                conexao.Close();
            }
            catch { }
            return null;
        }
        private DataTable selectAllSemPaginate(int id_dominio_ngestor, int id_sistemas_tipo)
        {
            try
            {
               
                SQLiteConnection conexao = new SQLiteConnection(_managerConnectionString);
                conexao.Open();

                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = '{id_dominio_ngestor}' AND id_sistemas_tipo = {id_sistemas_tipo}", conexao);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable datatable = new DataTable();
                da.Fill(datatable);
                conexao.Close();
                return datatable;

            }
            catch { }
            return null;
        }
       
    }
}
