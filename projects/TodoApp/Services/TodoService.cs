using MySql.Data.MySqlClient;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService
    {
        private readonly string _connectionString;

        public TodoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public List<TodoItem> GetTodosAdoNet(string? userId = null)
        {
            var todos = new List<TodoItem>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                if (userId == null)
                {
                    command.CommandText = "SELECT Id, Title, Description, IsCompleted, UserId FROM Todos";
                }
                else
                {
                    command.CommandText = "SELECT Id, Title, Description, IsCompleted, UserId FROM Todos WHERE UserId = @UserId";
                    command.Parameters.AddWithValue("@UserId", userId);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        todos.Add(new TodoItem
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            UserId = reader.GetString(4)
                        });
                    }
                }
            }

            return todos;
        }

        public void AddTodoAdoNet(TodoItem todo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Todos (Title, Description, IsCompleted, UserId) VALUES (@Title, @Description, @IsCompleted, @UserId)";
                command.Parameters.AddWithValue("@Title", todo.Title);
                command.Parameters.AddWithValue("@Description", todo.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted);
                command.Parameters.AddWithValue("@UserId", todo.UserId);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateTodoAdoNet(TodoItem todo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Todos SET Title = @Title, Description = @Description, IsCompleted = @IsCompleted WHERE Id = @Id AND UserId = @UserId";
                command.Parameters.AddWithValue("@Title", todo.Title);
                command.Parameters.AddWithValue("@Description", todo.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted);
                command.Parameters.AddWithValue("@Id", todo.Id);
                command.Parameters.AddWithValue("@UserId", todo.UserId);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteTodoAdoNet(int id, string userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Todos WHERE Id = @Id AND UserId = @UserId";
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@UserId", userId);

                command.ExecuteNonQuery();
            }
        }
    }
}