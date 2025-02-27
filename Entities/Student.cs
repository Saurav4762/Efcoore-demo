﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace saurav.Entities;

public class Student
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Address { get; set; }
    public int CourseId { get; set; }
    
    public virtual Course Course { get; set; }
    
}