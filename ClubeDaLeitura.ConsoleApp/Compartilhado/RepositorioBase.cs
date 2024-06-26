﻿using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class RepositorioBase
    {
        public List<EntidadeBase> cadastros = new List<EntidadeBase>();
        public int contadorId = 1;

        public void Cadastrar(EntidadeBase novoCadastro)
        {
            novoCadastro.Id = contadorId++;
            cadastros.Add(novoCadastro);
        }

        public EntidadeBase SelecionarPeloId(int id)
        {
            foreach (var cadastro in cadastros)
            {
                EntidadeBase e = (EntidadeBase)cadastro; //forçando o cadastro a ser uma entidade base

                if (e.Id == id)
                    return e;
            }
            return null;
        }

        public List<EntidadeBase> SelecionarTodos()
        {
            return cadastros;
        }
    }
}
