using AutoMapper;
using GTS.TodoApp.Core.Application.Abstraction.Services;
using GTS.TodoApp.Core.Application.Specifications;
using GTS.TodoApp.Core.Domain.Contracts;
using GTS.TodoApp.Core.Domain.Contracts.UnitOfWork;
using GTS.TodoApp.Core.Domain.Entities;
using GTS.TodoApp.Core.Domain.Entities._Common;
using GTS.TodoApp.Shared.DTOs;
using GTS.TodoApp.Shared.Helpers;

namespace GTS.TodoApp.Core.Application.Services
{
    public class TodoService(IUnitOfWork _unitOfWork, IMapper _mapper) : ITodoService
    {
        private readonly IGenericRepository<Todo, Guid> _todoRepository = _unitOfWork.GetRepository<Todo, Guid>();

        public async Task<Result<IEnumerable<TodoDTO>>> GetAllWithSpecsAsync(SpecParams specParams)
        {
            var todoSpecs = new TodoSpecifications(specParams);
            var todos = await _todoRepository.GetAllAsyc(todoSpecs);

            if (todos is null)
            {
                var failedResult = Result<IEnumerable<TodoDTO>>.Failure("Todo-list not found");
                failedResult.StatusCode = 404;
                return failedResult;
            }
            var todosDTO = _mapper.Map<IEnumerable<TodoDTO>>(todos);
            var successResult = Result<IEnumerable<TodoDTO>>.Success(todosDTO);
            successResult.StatusCode = 200;
            return  successResult;
        }

        public async Task<Result<TodoDTO>> GetTodoByIdAsync(Guid id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);

            if (todo is null)
            {
                var failedResult = Result<TodoDTO>.Failure("Failed to find this Todo");
                failedResult.StatusCode = 404;
                return failedResult;
            }

            var todoDTO = _mapper.Map<TodoDTO>(todo);
            var successResult = Result<TodoDTO>.Success(todoDTO);
            successResult.StatusCode = 200;
            return successResult;
        }

        public async Task<Result<TodoDTO>> CreateTodoAsync(TodoDTO todoDTO)
        {
            var todo = _mapper.Map<Todo>(todoDTO);
            if (todo is null)
            {
                var failedResult = Result<TodoDTO>.Failure("Creating failed through mapping.");
                failedResult.StatusCode = 400;
                return failedResult;
            }
            var result = await _todoRepository.AddAsync(todo);

            if (result)
            {
                await _unitOfWork.CompleteAsync();
                todoDTO.Id = todo.Id;
                var successResult = Result<TodoDTO>.Success(todoDTO);
                successResult.StatusCode =  200;
                return successResult;
            }
            var failed = Result<TodoDTO>.Failure("Creating failed,Maybe Internal Server Error.");
            failed.StatusCode = 500;
            return failed;
        }

        public async Task<Result<TodoDTO>> UpdateTodo(TodoDTO todoDTO)
        {
            var todo = _mapper.Map<Todo>(todoDTO);

            if (todo is null)
            {
                var failedResult = Result<TodoDTO>.Failure("Update failed through mapping");
                failedResult.StatusCode = 400;
                return failedResult;
            }

            todo.LastModifiedDate = DateTime.UtcNow;

            var result = _todoRepository.Update(todo);

            if (result)
            {
                await _unitOfWork.CompleteAsync();
                var successResult = Result<TodoDTO>.Success(todoDTO);
                successResult.StatusCode=200;
                return successResult;
            }
            var failed = Result<TodoDTO>.Failure("Failed to update this Todo,Internal Server Error");
            failed.StatusCode = 500;
            return failed;
        }

        public async Task<Result<bool>> DeleteTodo(TodoDTO todoDTO)
        {
            var todo = _mapper.Map<Todo>(todoDTO);

            if (todo is null)
            {
                var failedResult = Result<bool>.Failure("Failed to delete todo during mapping proccess");
                failedResult.StatusCode = 400;
                return failedResult;

            }

            var result = _todoRepository.Delete(todo);

            if (result)
            {
                await _unitOfWork.CompleteAsync();
                var successResult = Result<bool>.Success(true);
                successResult.StatusCode = 200;
                return successResult;

            }

            return Result<bool>.Failure("Failed to Delete this todo.");
        }

        public async Task<Result<string>> MarkAsCompleted(Guid id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);

            if (todo is null)
            {
                var failedResult = Result<string>.Failure("Failed to Find this Todo By Id");
                failedResult.StatusCode = 404;
                return failedResult;
            }

            todo.Status = SD_Status.Completed;

            await _unitOfWork.CompleteAsync();

            var successResult = Result<string>.Success(todo.Id.ToString());
            successResult.StatusCode = 200;
            return successResult;
        }

    }
}
