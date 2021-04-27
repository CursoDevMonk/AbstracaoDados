using System;
using System.Collections.Generic;
using System.Linq;
using Abstra_o_de_Dados.Models;

namespace Abstra_o_de_Dados.database
{
    abstract class RemoteDB
    {
        //ZzyHbz1sContext db = new ZzyHbz1sContext();
        protected Models.ZzyYHTbz1sContext db;

        protected int Commit()
        {
           return db.SaveChanges();
        }

        public RemoteDB()
        {
            db = new ZzyYHTbz1sContext();
        }

    } 
    interface ICrud
    {
        Models.TbAluno CadastrarAluno(Models.TbAluno aluno);
        void Alterar (int id, TbAluno aluno);

        void Remover(int id);
        List<TbAluno> Listar();
        List<TbAluno> Consultar (Func<TbAluno, bool> filter);
    }
    

     class AlunoDatabase: RemoteDB, ICrud
     {
        public TbAluno CadastrarAluno (Models.TbAluno aluno)
        {
            db.Add(aluno);
            Commit();
            return aluno;
        }
        public void Alterar(int id ,TbAluno aluno)
        {
            var Alterar = db.TbAluno.FirstOrDefault(x => x.IdAluno == id );
            Alterar.NmAluno = aluno.NmAluno;
            Alterar.NrChamada = aluno.NrChamada;
            Alterar.NmTurma = aluno.NmTurma;
            Commit();
        }
        public void Remover (int id)
        {
           TbAluno aluno = db.TbAluno.First(x => x.IdAluno == id);
           db.Remove(aluno);
           Commit();
        }
        public List<TbAluno> Listar()
        {
            List<TbAluno > alunos = db.TbAluno.ToList();
            return  alunos;
        }

        public List<TbAluno> Consultar (Func<TbAluno, bool> filter)
        {
            return db.TbAluno.Where(filter).ToList();
        }
        
        

     }
     
}