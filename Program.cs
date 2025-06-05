// See https://aka.ms/new-console-template for more information
using Npgsql;

Console.WriteLine("Hello, World!");
var connString = "Host=localhost;Port=5432;Username=postgres;Password=password;Database=postgres";
using var conn = new NpgsqlConnection(connString);
conn.Open();
using var cmd = new NpgsqlCommand("SELECT version();", conn);
var version = cmd.ExecuteScalar();
Console.WriteLine($"PostgreSQL version: {version}");

using var cmd1 = new NpgsqlCommand("INSERT INTO transactions (time, pan, amount, processing_code) VALUES (@time, @pan, @amount, @code)", conn);

cmd1.Parameters.AddWithValue("time", DateTime.UtcNow);
cmd1.Parameters.AddWithValue("pan", "1234567890123456");
cmd1.Parameters.AddWithValue("amount", 100.00m);
cmd1.Parameters.AddWithValue("code", "000000");
cmd1.ExecuteNonQuery();

