using System.Text.Json;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();



/* app.MapGet("/cursos", CadastroCursos);
app.MapGet("/turmas", CadastroTurmas);
 */

/* IResult AtualizarCursos(Cursos cursos){

    for (int i = 0; i < cursos.Count; i++)
    {
        if (cursos[i].Id == cursos.idCursos){
            cursos[i] = cursos;
            return TypedResults.NoContent();
        }
    }
    return TypedResults.NotFound();
} */

/* 
IResult GetCursos()
{
    return TypedResults.Ok(cursos);
}
IResult GetTurmas()
{
   return TypedResults.Ok(turmas);
}
 */
/* void CadastroCursos ()
{
    JsonSerializerOptions options = new JsonSerializerOptions();
    options.WriteIndented = true;
    string json = JsonSerializer.Serialize(cursos);
    string caminho = $"{Environment.CurrentDirectory}\\json\\cursos.json";
    File.WriteAllText(caminho, json);
}

void CadastroTurmas ()
{

  JsonSerializerOptions options = new JsonSerializerOptions();
    options.WriteIndented = true;
    string json = JsonSerializer.Serialize(turmas);
    string caminho2 = $"{Environment.CurrentDirectory}\\json\\turmas.json";
    File.WriteAllText(caminho2, json);
} */

void ListarTurmas ()
{
  try {
      string stringConexao ="server=localhost;uid=root;pwd=1234;database=integradorprojeto;";
      MySqlConnection conexao = new MySqlConnection(stringConexao);
      conexao.Open();

      MySqlCommand comando = new MySqlCommand();
      comando.Connection = conexao;
      comando.CommandText = "SELECT * FROM integradorprojeto.turmas";
      MySqlDataReader resultado = comando.ExecuteReader();
      while (resultado.Read()){
        int idTurmas = resultado.GetInt32("idTurmas");
        string nome_turmas = resultado.GetString("nome");
        string modalidade = resultado.GetString("modalidade");
        string requisitos  = resultado.GetString("requisitos");
        string Nível  = resultado.GetString("Nível");
        string Custo  = resultado.GetString("Custo");
        string Material  = resultado.GetString("Material");

        Console.WriteLine($"{idTurmas} - {nome_turmas} - {modalidade} - {requisitos} - {Nível} - {Custo} - {Material}");

      }
    } catch (MySqlException ex) {
        Console.WriteLine(ex);
    }
}

void ListarCursos () {
    try {
      string stringConexao ="server=localhost;uid=root;pwd=1234;database=integradorprojeto;";
      MySqlConnection conexao = new MySqlConnection(stringConexao);
      conexao.Open();

      MySqlCommand comando = new MySqlCommand();
      comando.Connection = conexao;
      comando.CommandText = "SELECT * FROM integradorprojeto.cursos";
      MySqlDataReader resultado = comando.ExecuteReader();
      while (resultado.Read()){
        int id = resultado.GetInt32("id");
        string nome_curso = resultado.GetString("nome");
        int vagas = resultado.GetInt32("vagas");
        string professor  = resultado.GetString("professor");
        bool Dispon = resultado.GetBoolean("dispon");
        int cargaH = resultado.GetInt32("cargaH");

        Console.WriteLine($"{id} - {nome_curso} - {vagas} - {professor} - {Dispon} - {cargaH}");

      }
    } catch (MySqlException ex) {
        Console.WriteLine(ex);
    }
}
app.Run();