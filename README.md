# ManagementSystem
## Overview

The **Student Management MVC** project is a web application built with **ASP.NET Core MVC**. It allows users to manage students and courses, providing functionalities for creating, reading, updating, and deleting (CRUD) both students and courses, with additional features like image handling and search.

---

## Controllers

### 1.CoursesController

This controller manages course-related actions.

#### Methods:

- **Index**: Retrieves and displays a list of all courses.
- **Details**: Displays the details of a selected course.
- **Create**: Provides a form to create a new course.
  - **POST Create**: Handles the creation of a course after form submission.
- **Edit**: Displays a form to edit an existing course.
  - **POST Edit**: Updates the course after form submission.
- **Delete**: Displays a delete confirmation page.
  - **POST Delete**: Deletes the selected course.
 
## 2. StudentsController

The `StudentsController` handles student-related actions, including displaying, adding, editing, and deleting students.

### Methods:

- **GetIndexView**: Displays a searchable list of students.
- **GetDetailsView**: Shows detailed information of a selected student, including their course.
- **GetCreateView**: Renders the form for adding a new student.
- **POST AddNew**: Processes student creation with image upload functionality.
- **GetEditView**: Displays a form to edit a student's details.
- **POST EditCurrent**: Handles student editing and image updates.
- **GetDeleteView**: Renders the delete confirmation page for a student.
- **POST DeleteCurrent**: Deletes the selected student and their associated image.
