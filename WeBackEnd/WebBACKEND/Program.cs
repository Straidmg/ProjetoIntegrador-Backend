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

List<Carro> carros = new List<Carro>();

// Crud:
// Create
// Read
// Update
// Delete
// JSON - JavaScript Object Notatiom

 Carro carro1 = new Carro(1, "412423432",2024, "carro", "marca boa",17, true);
 Carro carro2 = new Carro(2, "412423432",2023, "carro", "marca boa",17, false);
 carros.Add(carro1);
 carros.Add(carro2);
 
app.MapGet("/", CadastroCarro);
app.MapGet("/carros", GetCarros);
app.MapGet("/carro/{id}", GetCarro);
app.MapPost("/carros", InserirCarro);
app.MapDelete("/carro/{id}",DeletarCarro);
app.MapPut("/carros", AtualizarCarro);

app.MapGet("/clientes", ListarClientes);

void ListarClientes()
{
    try{
        string StringConexao = "server=localhost;uid=root;pwd=1234;database=MySql";
        MySqlConnection conexao = new MySqlConnection(StringConexao);
        conexao.Open();

        MySqlCommand comando = new MySqlCommand();
        comando.Connection = conexao;
        comando.CommandText = "SELECT * FROM sakila.clientes";
        MySqlDataReader resultado = comando.ExecuteReader();
        while (resultado.Read())
        {
            int id = resultado.GetInt32("id");
            string nome = resultado.GetString("nome");
            string senha = resultado.GetString("senha");
            string email = resultado.GetString("email");
            string usuario = resultado.GetString("usuario");

            Console.WriteLine($"{id} = {nome} = {senha} = {email} = {usuario}");
        }
    } catch (MySqlException ex)
    {
        Console.WriteLine(ex);
    }
}

IResult AtualizarCarro(Carro carro)
{
    for (int i = 0; i < carros.Count; i++)
    {
       if (carros[i].Id == carro.Id)
       {
        carros[i] = carro;
        return TypedResults.NoContent();
       } 
    }
    return TypedResults.NotFound();
}

IResult DeletarCarro(int id)
{
    for (int i = 0; i < carros.Count; i++)
    {
    if (carros[i].Id == id)
    {
        carros.RemoveAt(i);
        return TypedResults.NoContent();
    }    
    }
    return TypedResults.NotFound();
}

IResult InserirCarro(Carro carro)
{
    carros.Add(carro);

    return TypedResults.Created("/carro", carro);
}

IResult GetCarros()
{
    return TypedResults.Ok(carros);
}

IResult GetCarro(int id)
{
    foreach (Carro carro in carros)
    {
        if (carro.Id == id)
        {
            return TypedResults.Ok(carro);
        }
    }

    return TypedResults.NotFound();
}

void CadastroCarro()
{
    JsonSerializerOptions options = new JsonSerializerOptions();
    options.WriteIndented = true;
    string json= JsonSerializer.Serialize(carro1, options);
    string caminho = $"{Environment.CurrentDirectory}\\json\\estacionamento.json";
    File.WriteAllText(caminho, json);
}
app.Run();