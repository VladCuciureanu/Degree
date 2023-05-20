using AudioStreaming.Application.TodoLists.Queries.ExportTodos;

namespace AudioStreaming.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
