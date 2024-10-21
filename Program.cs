using System.Text.Json;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opcoes => {
  opcoes.AddPolicy(name: "padrao", politica => {
        politica.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseCors("padrao");

List<Cursos> cursos = new List<Cursos>();
List<Turmas> turmas = new List<Turmas>();

app.MapGet("/cursos", CadastroCursos);
app.MapGet("/turmas", CadastroTurmas);
app.MapGet("/cursos/", GetCursos);
app.MapGet("/turmas/", GetTurmas);
app.MapGet("/cursos/{idCursos}", GetCursos);
app.MapGet("/turmas/{idTurmas}", GetTurmas);
/* app.MapPost("/cursos", InserirCursos);
app.MapPost("/turmas", InserirTurmas);
app.MapPut("/cursos", AtualizarCursos);
app.MapPut("/turmas", AtualizarTurmas); */
app.MapDelete("/cursos/{idCursos}", DeletarCursos);
app.MapDelete("/turmas/{idTurmas}", DeletarTurmas);


/* IResult AtualizarCursos(Cursos cursos)
{
    for (int i = 0; i < cursos.Count; i++)
    {
       if (cursos[i].Id == cursos.idCursos)
       {
        cursos[i] = cursos;
        return TypedResults.NoContent();
       } 
    }
    return TypedResults.NotFound();
}
IResult AtualizarTurmas(Turmas turmas)
{
    for (int i = 0; i < turmas.Count; i++)
    {
       if (turmas[i].Id == turmas.idTurmas)
       {
        turmas[i] = turmas;
        return TypedResults.NoContent();
       } 
    }
    return TypedResults.NotFound();
} */

IResult DeletarCursos(int idCursos)
{
    for (int i = 0; i < cursos.Count; i++)
    {
    if (cursos[i].idCursos == idCursos)
    {
        cursos.RemoveAt(i);
        return TypedResults.NoContent();
    }    
    }
    return TypedResults.NotFound();
}

IResult DeletarTurmas(int idTurmas)
{
    for (int i = 0; i < turmas.Count; i++)
    {
    if (turmas[i].idTurmas == idTurmas)
    {
        turmas.RemoveAt(i);
        return TypedResults.NoContent();
    }    
    }
    return TypedResults.NotFound();
}
/* IResult InserirCursos(Cursos cursos)
{
    cursos.Add(cursos);

    return TypedResults.Created("/cursos", cursos);
}
IResult InserirTurmas(Turmas turmas)
{
    turmas.Add(turmas);

    return TypedResults.Created("/turmas", turmas);
} */

IResult GetCursos(int id)
{
    foreach (Cursos cursos in cursos)
    {
        if (cursos.idCursos == id)
        {
            return TypedResults.Ok(cursos);
        }
    }

    return TypedResults.NotFound();
}
IResult GetTurmas(int id)
{
    foreach (Turmas turmas in turmas)
    {
        if (turmas.idTurmas == id)
        {
            return TypedResults.Ok(turmas);
        }
    }

    return TypedResults.NotFound();
}






void CadastroCursos ()
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
}

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