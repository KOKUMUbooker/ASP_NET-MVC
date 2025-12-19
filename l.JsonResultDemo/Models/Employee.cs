namespace l.JsonResultDemo.Models;

  // Define the Employee class
public class Employee
{
    // Read-write properties
    public int Id { get; set; } 
    public string? FirstName { get; set; } 
    public int Age { get; set; } 
    public string? Occupation { get; set; } 
    // Read-only property
    public string? Address { get; set; } 
    // Mixed case property names
    public string? mixedCaseProperty { get; set; } 
    // Property with private setter to make it read-only for serialization
    public string ReadOnlyPropertyWithPrivateSetter { get; private set; } = "ReadOnlyValue"; 
    // Property with null value to show DefaultIgnoreCondition
    public string? NullValueProperty { get; set; } 
}