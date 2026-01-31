using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Repository
{
    public interface IFuncionariosRepository
    {
        Task<IEnumerable<Funcionario>> BuscarFuncionarios();
        Task<Funcionario> CriarFuncionario(Funcionario funcionario);
        Task<IEnumerable<Funcionario>> BuscarListaFuncionarioLoginNome();
        Task<bool> ValidaLogin(string login, string senha);
        Task<Funcionario> MudarSenha(Funcionario funcionario);
    }
    public class FuncionariosRepository
    {
        private readonly AppDbContext _appDbContext;

        public FuncionariosRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Busca todos os funcionários employeers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Funcionario>> BuscarFuncionarios()
        {
            var Funcionarios = await _appDbContext.employees.ToListAsync();
            return Funcionarios;
        }
        /// <summary>
        /// Cria o funcionário no banco employeers
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Funcionario> CriarFuncionario(Funcionario funcionario)
        {
            await _appDbContext.employees.AddAsync(funcionario);
            return funcionario;
        }


        /// <summary>
        /// Select normal mas só retorna nome completo e login
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Funcionario>> BuscarListaFuncionarioLoginNome()
        {
            var funcionarios = await _appDbContext.employees
              .Select(e => new Funcionario
              {
                  EmployeeFullName = e.EmployeeFullName,
                  EmployeeLogin = e.EmployeeLogin
              })
              .ToListAsync();
            return funcionarios;
        }

        /// <summary>
        /// Valida login (está da forma errada ainda MAS vou arrumar com a hash no futuro)
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public async Task<bool> ValidaLogin(string login, string senha)
        {
            bool localizado = await _appDbContext.employees
            .AnyAsync(e => e.EmployeeLogin == login && e.employeePassword == senha);

            return localizado;
        }

        /// <summary>
        /// Busca o funcionário e atualiza seu valor da senha.
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Funcionario> MudarSenha(Funcionario funcionario)
        {
            var funcionarioAntigo = await _appDbContext.employees.FindAsync(funcionario.EmployeeID);

            funcionarioAntigo?.employeePassword = funcionario.employeePassword;
            if (funcionarioAntigo == null)
            {
                return new Funcionario();
            }
            await _appDbContext.SaveChangesAsync();
            return funcionario;
        }





    }
}