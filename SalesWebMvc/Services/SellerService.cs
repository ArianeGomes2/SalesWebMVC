﻿using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)//construtor para que3 a injeção de dependencias possa acontecer
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList(); //acessa a fonte de dados dos vendedores e retorna uma lista
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj); //insere o objeto no banco de dados
            _context.SaveChanges(); //confirmar no banco de dados
        }
    }
}