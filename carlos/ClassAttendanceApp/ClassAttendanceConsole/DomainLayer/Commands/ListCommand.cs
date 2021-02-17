﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using DomainLayer.Contracts;
using DomainLayer.Entities;

namespace DomainLayer.Commands
{
    public class ListCommand : CommandBase
    {
        private IDatabase _database;

        public ListCommand(IDatabase database)
        {
            _database = database;
        }
        
        // list             : list all students on the course
        // list class       : list all classes in the course
        // list class <#>   : list topics for the # class 
        // list student <#> : list the student with id #
        // list student 15 
        
        public override CommandResult Execute()
        {
            if (string.IsNullOrWhiteSpace(_entityType))
            {
                _entityType = "student";
            }

            switch (_entityType)
            {
                case "student": 
                    ListStudent(_id); 
                    break;
                case "class": 
                    ListClass(_id);
                    break;
                case "course":
                    ListCourse(_id);
                    break;
                case "teacher":
                    ListTeacher(_id);
                    break;
                case "ta":
                    ListTeacherAssistant(_id);
                    break;
            }
            
            return CommandResult.OkResult();
        }

        private void ListTeacherAssistant(int id)
        {
            
        }

        private void ListTeacher(int id)
        {
            
        }

        public override string GetHelpText()
        {
            return
@"      Overview: 
            Displays student, class and course summary and detail information
            enter the entity name after the list command for 
    
        Usage: 
            list <entity> <id>      
            <entity>: is one of 'student','class','course' default value is student
                <id>: is a number according to the entity range from 1 to max records
        
        Examples
            :> list                 : display all students on the course
            :> list class           : display all classes in the course     
            :> list class 3         : display topics for classes number 3
            :> list student         : display all students     
            :> list student 15      : display detail information for student with id 15     
            :> list course          : display course information 
";
        }

        

        private void ListCourse(int courseNumber)
        {

        }

        private void ListClass(int classNumber)
        {

        }

        private void ListStudent(int studentNumber)
        {
            if (studentNumber > 0)
            {
                _database.GetStudent(studentNumber);
            }

            var allStudents = GetAllStudents();

            foreach (var student in allStudents)
            {
                Console.WriteLine("FirstName:" + student.FirstName + " LastName:" + student.LastName);
            }
        }

        private IEnumerable<Student> GetAllStudents()
        {
            return Enumerable.Empty<Student>();
        }
    }
}