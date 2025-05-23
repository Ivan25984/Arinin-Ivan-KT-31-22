namespace WebApplication1.Models
{
    public class WorkTime
    {
        public int WorkTimeId { get; set; } // Идентификатор рабочего времени
        public int WorkTimeHours { get; set; } // Количество часов
        public int ProfessorId { get; set; } // ID профессора
        public int DepartmentId { get; set; } // ID кафедры
        public int DisciplineId { get; set; } // ID дисциплины

        public Professor Professor { get; set; } // Навигационное свойство для профессора
        public Department Department { get; set; } // Навигационное свойство для кафедры
        public Discipline Discipline { get; set; } // Навигационное свойство для дисциплины
    }
}