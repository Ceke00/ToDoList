# Todo List Application

## Overview
This is a console-based Todo List application written in C#. 
It allows users to manage their tasks efficiently by adding, editing, and removing tasks. 
The application supports task prioritization and provides a user-friendly interface for editing tasks without requiring the user to re-enter all details.

This project was developed as a final project for an introductory course in C#.

## Features
- **Add New Tasks**: Users can add new tasks with a title, due date, category, and priority.
- **Edit Tasks**: Users can edit existing tasks. When editing, users can press Enter to keep the current value for any field.
- **Task Prioritization**: Tasks can be assigned a priority level (Urgent, High, Medium, Low).
- **Task Status**: Tasks can be marked as done or not done.
- **Task Listing**: Tasks can be sorted by date, category or priority. Most urgent tasks in the lists are marked with yellow (priority high or urgent, or due date is today or a passed date). Finished tasks ar marked with green.
- **Save and Load Tasks**: Tasks are saved to a file and loaded upon application start.

## Usage
1. **Main Menu**: The application starts with a main menu where you can choose to show the task list, add a new task, edit a task, or save and quit.
2. **Show Task List**: Order list by due date, category or priority. 
3. **Adding Tasks**: Follow the prompts to enter the task title, due date, category, and priority.
4. **Editing Tasks**: Select a task to edit. When updating you can press Enter to keep the current value for any field. You can also mark or unmark a task as done or remove the task.
6. **Saving and Loading**: Tasks are automatically loaded from `tasks.json` on startup and saved to `tasks.json` when you choose to save and quit.

