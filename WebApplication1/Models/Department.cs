using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } // Идентификатор кафедры
        public string DepartmentName { get; set; } // Название кафедры
        public DateTime DepartmentCreationDate { get; set; } // Дата основания
        public string DepartmentMainProfessor { get; set; } // Старший преподаватель кафедры
        public int DepartmentProfessorsAmount { get; set; }

        public ICollection<Professor> Professors { get; set; } // Связь с профессорами
    }
}