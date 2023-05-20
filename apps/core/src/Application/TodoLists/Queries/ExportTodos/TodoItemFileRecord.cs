using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Domain.Entities;

namespace AudioStreaming.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
