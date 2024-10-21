using System.IO.Pipes;
using System.Net.NetworkInformation;

class Turmas {

    public int idTurmas { get; set;}
    public string Nome {get; set;}
    public string Modalidade {get; set;}

    public string Requisitos {get; set;}
    public string Nível {get; set;}
    public string Custo {get; set;}
    public string Material {get; set;}


    public Turmas (int id, string nome, string modalidade, string req, string nvl, string cst, string Mat)

    {
     idTurmas = id;
     Nome = nome;
     Modalidade = modalidade;
     Requisitos = req;
     Nível = nvl;
     Custo = cst;
     Material = Mat;
    }
}

/* `idTurmas` INT NOT NULL,
  `Nome` VARCHAR(45) NULL,
  `Modadlidade` VARCHAR(45) NULL,
  `Requisitos` VARCHAR(45) NULL,
  `Nível` VARCHAR(45) NULL,
  `Custo` VARCHAR(45) NULL,
  `Material` VARCHAR(45) NULL,
  PRIMARY KEY (`idTurmas`));

 */