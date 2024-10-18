using System.IO.Pipes;
using System.Net.NetworkInformation;

class Cursos {

    public int idCursos { get; set;}
    public string Nome {get; set;}
    public int Vagas {get; set;}

    public string Professor {get; set;}
    public bool Dispon {get; set;}
    public int CargaH {get; set;}

    public Cursos(int id, string nome, int vagas, string professor, bool dispon, int cargaH)

    {
     idCursos = id;
     Nome = nome;
     Vagas = vagas;
     Professor = professor;
     Dispon = dispon;
     CargaH = cargaH;
    }
}





//`idCursos` INT NOT NULL,
//  `Nome` VARCHAR(45) NULL,
//  `Vagas` INT NULL,
 // `Professor` VARCHAR(45) NULL,
 // `Disponibilidade` INT NULL,
 // `Carga Horaria` INT NULL,
