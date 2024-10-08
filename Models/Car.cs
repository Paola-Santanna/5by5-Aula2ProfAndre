﻿namespace Models
{
    public class Car
    {
        public static readonly string INSERT = "INSERT INTO TB_CAR (Name, Color, Year) values (@Name, @Color, @Year)";
        public static readonly string UPDATE = "UPDATE TB_CAR set Name = @Name,  Color = @Color, Year = @Year WHERE Id = @Id";
        public static readonly string DELETE = "DELETE FROM TB_CAR WHERE Id = @Id";
        public static readonly string GET = "SELECT Id, Name, Color, Year FROM TB_CAR WHERE Id = @Id";
        public static readonly string GET_ALL = "SELECT Id, Name, Color, Year FROM TB_CAR";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public Car() { }

        public override string ToString()
        {
            return $"Id: {Id}; Nome: {Name}; Cor: {Color}: Ano: {Year}";
        }
    }
}
