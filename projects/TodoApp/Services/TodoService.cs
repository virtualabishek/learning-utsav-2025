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

        public List<TodoItem> GetTodosAdoNet()
        {
            var todos = new List<TodoItem>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Title, Description, IsCompleted FROM Todos";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        todos.Add(new TodoItem
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3)
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
                command.CommandText = "INSERT INTO Todos (Title, Description, IsCompleted) VALUES (@Title, @Description, @IsCompleted)"; // Changed 'Todo' to 'Todos'
                command.Parameters.AddWithValue("@Title", todo.Title);
                command.Parameters.AddWithValue("@Description", todo.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted);

                command.ExecuteNonQuery();
            }
        }
    }
}