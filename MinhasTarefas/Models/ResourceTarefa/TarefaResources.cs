using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhasTarefas.Data;
using MinhasTarefas.ViewModels;
using System.Globalization;

namespace MinhasTarefas.Models.ResourceTarefa
{
    public class TarefaResources
    {
        #region Atributos
        private readonly AppDbContext _context;
        #endregion

        #region Construtor
        public TarefaResources(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        public async Task<List<Tarefa>> ListTodasTarefasAsync()
        {
            try
            {
                var tarefas = await _context
                    .Tarefas //Dbset<Tarefa>
                    .AsNoTracking()
                    .ToListAsync();
                return tarefas;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<Tarefa> ListTarefaIdAsync(int id)
        {
            try
            {
                var tarefa = await _context
                .Tarefas //Dbset<Tarefa>
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

                return tarefa;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<Tarefa> AdicionarTarefaAsync(CreateTarefaViewModel tarefa, string idUser)
        {
            var tarefaObj = new Tarefa
            {
                Title = tarefa.Title,
                Description = tarefa.Description,
                Date = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Status = tarefa.Status,
                CreationUserId = int.Parse(idUser),
                LastUpdateDate = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)

            };

            try
            {
                await _context.Tarefas.AddAsync(tarefaObj);
                await _context.SaveChangesAsync();

                return tarefaObj;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<dynamic> AtualizarTarefaAsync(int id, UpdateTarefaViewModel updateTarefaViewModel, string userId)
        {
            var userIdRequisitoin = int.Parse(userId);
            var tarefaObj = await _context
                .Tarefas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (tarefaObj == null)
                return default;

            if (tarefaObj.CreationUserId != userIdRequisitoin)
            {
                return new StatusCodeResult(403);
            }

            try
            {
                if (!string.IsNullOrEmpty(updateTarefaViewModel.Title))
                {
                    tarefaObj.Title = updateTarefaViewModel.Title;
                }

                if (!string.IsNullOrEmpty(updateTarefaViewModel.Description))
                {
                    tarefaObj.Description = updateTarefaViewModel.Description;
                }

                if (!string.IsNullOrEmpty(updateTarefaViewModel.Status))
                {
                    tarefaObj.Status = updateTarefaViewModel.Status;
                }

                _context.Tarefas.Update(tarefaObj);
                await _context.SaveChangesAsync();
                return tarefaObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<dynamic> DeleteTarefaAsync(int id, string userId)
        {
            var userIdRequisitoin = int.Parse(userId);

            var tarefa = await _context
                .Tarefas
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                if (tarefa == null || tarefa.CreationUserId != userIdRequisitoin) return false;

                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
