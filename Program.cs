// o que é isso aqui?
using System.Text;
using DesafioProjetoHospedagem.Models;
using Newtonsoft.Json;
// criptografia nativa? eita! *_*
// using System.Security.Cryptography;

Console.OutputEncoding = Encoding.UTF8;

// Olá, resolvi treinar a leitura de arquivos e conversão de json neste desafio 

String response = File.ReadAllText("./database/database.json");

// JsonConvert.DeserializeObject<List<Pessoa>>(response); /// EU SEI, OK?!
List<object> data =  JsonConvert.DeserializeObject<List<object>>(response);

List<Pessoa> hospedes = new List<Pessoa>(); 

Pessoa p1 = new Pessoa(nome: "Hóspede sem graça 1");
Pessoa p2 = new Pessoa(nome: "Hóspede sem graça 2");

foreach (object item in data)
{
// Bem melhor...
Pessoa p = JsonConvert.DeserializeObject<Pessoa>(item.ToString());
Console.WriteLine(p.Sobrenome); // testando o JsonProperty com lastname aqui... NOSSA! bem melhor que no Dart!
hospedes.Add(p); 
}


hospedes.Add(p1);
 hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Hyper Mansão Prime Gourmet do tio Linus", capacidade: 600, valorDiaria: 30000);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 10);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária 
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor da Entrada: {reserva.CalcularValorDiaria()}");