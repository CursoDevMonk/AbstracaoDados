using System;
using System.Collections.Generic;
using System.Linq;
using Abstra_o_de_Dados.Models;

namespace Abstra_o_de_Dados
{
    class Program
    {
        static void Main(string[] args)
        {
            database.AlunoDatabase db = new database.AlunoDatabase();
            

            // consultar
            List<TbAluno> alunos = db.Listar();
            alunos.ForEach(x => 
                Console.WriteLine($"ID: {x.IdAluno}, Nome:{x.NmAluno}, Número: {x.NrChamada}, Turma: {x.NmTurma}"));
            

            // cadastrar
            TbAluno aluno = new TbAluno() {
                NmAluno = "Alexa, Bia, Mayara, Rebecca, Sthefany",
                NrChamada = 10,
                NmTurma = "DevMonkGirls"
            };
            Models.TbAluno alunoSalvo = db.CadastrarAluno(aluno);  
            

            // alterar
            aluno.NrChamada = 1000;
            db.Alterar(alunoSalvo.IdAluno, aluno);
            
            
            // remover
            db.Remover(30);
        }
    }
}
