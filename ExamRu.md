### Техническое задание: Сервисы бэкенда для системы управления обучением (Learning Management System, LMS)
## Обзор
 Это техническое задание направлено на проектирование и реализацию бэкенд-сервиса для системы управления обучением с использованием .NET Core и Entity Framework Core. Целью является разработка набора API, которые управляют курсами, материалами, студентами, заданиями, отправками и обратной связью в образовательном контексте. Этот проект даст практический опыт построения надежной бэкенд-системы с использованием лучших практик разработки на .NET Core.

# Цели
- Реализация операций CRUD для основных сущностей в LMS.
- Понимание и применение лучших практик Entity Framework Core для моделирования данных и управления базой данных.
- Разработка четкого понимания архитектуры на основе сервисов с использованием .NET Core.
- Получение опыта работы с отношениями данных и бизнес-логикой в образовательном контексте.
# Инструменты и технологии
- .NET Core 8
- Entity Framework Core
- PostgreSQL или любая совместимая база данных
- Visual Studio или VS Code или Rider
# Сущности
# Курс (Course)
- Id (int)
- Title (string)
- Description (string)
- Instructor (string)
- Credits (int)
# Материал (Material)
- Id (int)
- CourseId (int) [Внешний ключ]
- Title (string)
- Description (string)
- ContentUrl (string)
# Студент (Student)
- Id (int)
- Name (string)
- Email (string)
- EnrollmentDate (DateTime)
# Задание (Assignment)
- Id (int)
- CourseId (int) [Внешний ключ]
- Title (string)
- Description (string)
- DueDate (DateTime)
# Отправка (Submission)
- Id (int)
- AssignmentId (int) [Внешний ключ]
- StudentId (int) [Внешний ключ]
- SubmissionDate (DateTime)
- Content (string)
# Обратная связь (Feedback)
- Id (int)
- AssignmentId (int) [Внешний ключ]
- StudentId (int) [Внешний ключ]
- Text (string)
- FeedbackDate (DateTime)
# Диаграмма
erDiagram
Course ||--o{ Material : "has"
Course ||--o{ Assignment : "has"
Assignment ||--o{ Submission : "has"
Assignment ||--o{ Feedback : "has"

    Course {
        int Id "Уникальный идентификатор"
        string Title "Название курса"
        string Description "Описание курса"
        string Instructor "Преподаватель курса"
        int Credits "Кредиты курса"
    }

    Material {
        int Id "Уникальный идентификатор"
        int CourseId "Ссылка на курс"
        string Title "Название материала"
        string Description "Описание материала"
        string ContentUrl "URL для доступа к содержимому"
    }

    Student {
        int Id "Уникальный идентификатор"
        string Name "Имя студента"
        string Email "Адрес электронной почты"
        datetime EnrollmentDate "Дата зачисления"
    }

    Assignment {
        int Id "Уникальный идентификатор"
        int CourseId "Ссылка на курс"
        string Title "Название задания"
        string Description "Описание задания"
        datetime DueDate "Крайний срок выполнения задания"
    }

    Submission {
        int Id "Уникальный идентификатор"
        int AssignmentId "Ссылка на задание"
        int StudentId "Ссылка на студента"
        datetime SubmissionDate "Дата отправки"
        string Content "Отправленное содержимое"
    }

    Feedback {
        int Id "Уникальный идентификатор"
        int AssignmentId "Ссылка на задание"
        int StudentId "Ссылка на студента"
        string Text "Текст обратной связи"
        datetime FeedbackDate "Дата обратной связи"
    }
}

### Сервисы
- Каждый слой сервиса должен содержать бизнес-логику для управления своей соответствующей сущностью.

# CourseService
- AddCourse: Метод для добавления нового курса.
- UpdateCourse: Метод для обновления информации о курсе.
- DeleteCourse: Метод для удаления курса.
- GetCourseWithMaterials: Метод для получения информации о курсе вместе с материалами с использованием LINQ.
- GetCourse: Метод для получения информации о курсе.
- GetCourseById: Метод для получения информации о курсе по его Id.
# MaterialService
- AddMaterial: Метод для добавления нового материала для курса.
- UpdateMaterial: Метод для обновления информации о материале.
- DeleteMaterial: Метод для удаления материала.
- GetMaterialForCourse: Метод для получения материалов для определенного курса с использованием LINQ.
- GetMaterial: Метод для получения информации о материале.
- GetMaterialById: Метод для получения информации о материале по его Id.
# StudentService
- AddStudent: Метод для добавления нового студента.
- UpdateStudent: Метод для обновления информации о существующем студенте.
- DeleteStudent: Метод для удаления студента.
- GetStudent: Метод для получения информации о студенте.
- GetStudentById: Метод для получения информации о студенте по его Id.
# AssignmentService
- CreateAssignment: Метод для создания нового задания для курса.
- UpdateAssignment: Метод для обновления информации о задании.
- DeleteAssignment: Метод для удаления задания.
- GetAssignment: Метод для получения информации о задании.
- GetAssignmentById: Метод для получения информации о задании по его Id.
# SubmissionService
- SubmitAssignment: Метод для отправки задания студентом.
- GetSubmissionsForAssignment: Метод для получения всех отправок для определенного задания.
- GetSubmissionById: Метод для получения информации о отправке по ее Id.
# FeedbackService
- ProvideFeedback: Метод для предоставления обратной связи по заданию студента.
- GetFeedbackForAssignment: Метод для получения обратной связи по определенному заданию.
- GetFeedbackById: Метод для получения информации об обратной связи по ее Id.
# QueryService
- Получить общее количество отправок для каждого студента, отсортированных по количеству отправок в порядке убывания.
- Получить список студентов, которые не отправили ни одного задания для определенного курса (например, на C#).
- Получить список курсов с общим количеством материалов.
- Получить список студентов, которые отправили все задания вовремя для всех курсов, на которые они зачислены.
## Настройка базы данных
- Используйте миграции EF Core для настройки схемы базы данных.
- Заполните базу данных начальными данными для тестирования.
# Разработка API
- Реализация API для операций CRUD для каждой сущности.
- Реализация API для отправки заданий, предоставления обратной связи и получения отправок.
# Валидация
- Реализация валидации данных для обеспечения целостности входящих данных.
# Отправка
- Загрузите проект на GitHub, содержащий весь исходный код.
# Критерии оценки
- Организация и качество кода.
- Правильная реализация операций CRUD и слоев сервиса.
- Эффективное использование Entity Framework Core для управления данными.
- Обработка крайних случаев и потенциальных ошибок.
# Используемые инструменты
- AutoMapper
- Try-catch
- Ответ (Response)
- Пагинированный ответ (PagedResponse)
- Фильтр (Filter)