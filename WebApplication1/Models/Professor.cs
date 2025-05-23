using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; } // Идентификатор профессора
        public string ProfessorFirstName { get; set; } // Имя профессора
        public string ProfessorLastName { get; set; } // Фамилия профессора
        public string ProfessorMiddleName { get; set; } // Отчество профессора
        public string ProfessorTitle { get; set; } // Должность профессора
        public int DepartmentId { get; set; } // ID кафедры

        public Department Department { get; set; } // Навигационное свойство для кафедры
    }
}