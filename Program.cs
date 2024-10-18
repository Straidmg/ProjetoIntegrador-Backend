using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Cursos> cursos = new List<Cursos>();

Cursos cursos1 = new Cursos(1,"Cientista de Dados",20,"Everton",true,230);
Cursos cursos2 = new Cursos(2,"Segurança de Trabalho",40,"Nailton",false,430);
Cursos cursos3 = new Cursos(3,"Manutenção Atomotiva",10,"Geraldo",true,500);

cursos.Add(cursos1);
cursos.Add(cursos2);

app.MapGet("/", CadastroCursos);


//IResult AtualizarCursos(Cursos cursos){

//    for (int i = 0; i < cursos.Count; i++)
  //  {
    //    if (cursos[i].Id == cursos.idCursos){
      //      cursos[i] = cursos;
        //    return TypedResults.NoContent();
       // }
   // }
   // return TypedResults.NotFound();
//}


IResult GetCursos()
{
    return TypedResults.Ok(cursos);
}

void CadastroCursos ()
{
    JsonSerializerOptions options = new JsonSerializerOptions();
    options.WriteIndented = true;
    string json = JsonSerializer.Serialize(cursos);
    string caminho = $"{Environment.CurrentDirectory}\\json\\cursos.json";
    File.WriteAllText(caminho, json);
}

app.Run();