class Carro
{
    public int Id{get; set;}

    public string Placa{get; set;}

    public string Modelo{get; set;}

    public int Ano{get; set;}

    public string Marca{get; set;}

    public int HoraChegada{get; set;}

    public bool Mensalista{get; set;}

    public Carro(int id, string placa, int ano, string modelo, string marca, int horaChegada, bool mensalista)
    {
        Id = id;
        Placa = placa;
        Ano = ano;
        Modelo = modelo;
        Marca = marca;
        HoraChegada = horaChegada;
        Mensalista = mensalista;
    }
}