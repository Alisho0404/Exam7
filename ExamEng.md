# Technical Assignment: Learning Management System (LMS) Backend Services

## Overview

This technical assignment focuses on designing and implementing a backend service for a Learning Management System (LMS) using .NET Core and Entity Framework Core. The objective is to develop a set of APIs that manage courses, materials, students, assignments, submissions, and feedback within the educational context. This project will provide hands-on experience with building a robust backend system using best practices in .NET Core development.

## Objectives

- Implement CRUD operations for essential entities in the LMS.
- Understand and apply best practices in Entity Framework Core for data modeling and database management.
- Develop a clear understanding of service-oriented architecture using .NET Core.
- Gain experience in handling data relationships and business logic within an educational context.

## Tools and Technologies

- .NET Core 8
- Entity Framework Core
- PostgreSQL or any compatible database
- Visual Studio or VS Code or Rider

## Entities

### Course

- Id (int)
- Title (string)
- Description (string)
- Instructor (string)
- Credits (int)

### Material

- Id (int)
- CourseId (int) [Foreign Key]
- Title (string)
- Description (string)
- ContentUrl (string)

### Student

- Id (int)
- Name (string)
- Email (string)
- EnrollmentDate (DateTime)

### Assignment

- Id (int)
- CourseId (int) [Foreign Key]
- Title (string)
- Description (string)
- DueDate (DateTime)

### Submission

- Id (int)
- AssignmentId (int) [Foreign Key]
- StudentId (int) [Foreign Key]
- SubmissionDate (DateTime)
- Content (string)

### Feedback

- Id (int)
- AssignmentId (int) [Foreign Key]
- StudentId (int) [Foreign Key]
- Text (string)
- FeedbackDate (DateTime)

## Diagram

erDiagram
Course ||--o{ Material : "has"
Course ||--o{ Assignment : "has"
Assignment ||--o{ Submission : "has"
Assignment ||--o{ Feedback : "has"

    Course {
        int Id "Unique identifier"
        string Title "Course title"
        string Description "Course description"
        string Instructor "Course instructor"
        int Credits "Course credits"
    }

    Material {
        int Id "Unique identifier"
        int CourseId "Reference to Course"
        string Title "Material title"
        string Description "Material description"
        string ContentUrl "URL to access content"
    }

    Student {
        int Id "Unique identifier"
        string Name "Student's name"
        string Email "Email address"
        datetime EnrollmentDate "Date of enrollment"
    }

    Assignment {
        int Id "Unique identifier"
        int CourseId "Reference to Course"
        string Title "Assignment title"
        string Description "Assignment description"
        datetime DueDate "Due date for the assignment"
    }

    Submission {
        int Id "Unique identifier"
        int AssignmentId "Reference to Assignment"
        int StudentId "Reference to Student"
        datetime SubmissionDate "Date of submission"
        string Content "Submitted content"
    }

    Feedback {
        int Id "Unique identifier"
        int AssignmentId "Reference to Assignment"
        int StudentId "Reference to Student"
        string Text "Feedback text"
        datetime FeedbackDate "Date of feedback"
    }
}

## Services

Each service layer should contain business logic for managing its respective entity.

### CourseService

- AddCourse: Method to add a new course.
- UpdateCourse: Method to update course details.
- DeleteCourse: Method to delete a course.
- GetCourseWithMaterials: Method to retrieve course details along with its materials using LINQ.
- GetCourse: Method to retrieve course details.
- GetCourseById: Method to retrieve course details by course Id.

### MaterialService

- AddMaterial: Method to add a new material for a course.
- UpdateMaterial: Method to update material details.
- DeleteMaterial: Method to delete a material.
- GetMaterialForCourse: Method to retrieve materials for a specific course using LINQ.
- GetMaterial: Method to retrieve material details.
- GetMaterialById: Method to retrieve material details by material Id.

### StudentService

- AddStudent: Method to add a new student.
- UpdateStudent: Method to update existing student information.
- DeleteStudent: Method to delete a student.
- GetStudent: Method to retrieve student details.
- GetStudentById: Method to retrieve student details by student Id.

### AssignmentService

- CreateAssignment: Method to create a new assignment for a course.
- UpdateAssignment: Method to update assignment details.
- DeleteAssignment: Method to delete an assignment.
- GetAssignment: Method to retrieve assignment details.
- GetAssignmentById: Method to retrieve assignment details by assignment Id.

### SubmissionService

- SubmitAssignment: Method for a student to submit an assignment.
- GetSubmissionsForAssignment: Method to retrieve all submissions for a specific assignment.
- GetSubmissionById: Method to retrieve submission details by submission Id.

### FeedbackService

- ProvideFeedback: Method to provide feedback on a student's assignment.
- GetFeedbackForAssignment: Method to retrieve feedback for a specific assignment.
- GetFeedbackById: Method to retrieve feedback details by feedback Id.

### QueryService
- Get the total number of submissions for each student, sorted by the number of submissions in descending order.
- Get a list of students who have not submitted any assignments for a specific course (e.g., in C#).
- Get a list of courses with the total number of materials.
- Get a list of students who have submitted all assignments on time for all courses they are enrolled in.

### Database Setup

- Utilize EF Core migrations to set up the database schema.
- Seed the database with initial data for testing purposes.

### API Development

- Implement APIs for CRUD operations for each entity.
- Implement APIs for submitting assignments, providing feedback, and retrieving submissions.


### Validation

- Implement data validation to ensure the integrity of incoming data.


## Submission intelines

- Submit the project on GitHub containing all source code.

## Evaluation Criteria

- Code organization and quality.
- Correct implementation of CRUD operations and service layers.
- Effective use of Entity Framework Core for data management.
- Handling of edge cases and potential errors.

## Using
- AutoMapper
- Try-catch
- Response
- PagedResponse
- Filter
