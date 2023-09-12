using Ef_core_Table_Sharing_Issue_Demo;
using Ef_core_Table_Sharing_Issue_Demo.Model;

using var db = new ApplicationContext();

var exactUser = new ExactUser { Name = "ExactUser" };
db.ExactUsers.Add(exactUser);
db.SaveChanges();

Console.WriteLine($"Exact user Id: {exactUser.Id}, Name: {exactUser.Name}");

var sharedUserFromDb = db.SharedUsers.SingleOrDefault();

Console.WriteLine($"Exact user Id: {sharedUserFromDb?.Id}, Name: {sharedUserFromDb?.Name}");

var sharedUser = new SharedUser { Name = "SharedUser" };

db.SharedUsers.Add(sharedUser);
db.SaveChanges(); // Invalid operation exception
