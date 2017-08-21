# TylerApp
Description:

I have developed the two screens of the application. 
The first Screen is ViewEmployeeList which is used to view the Employees under a certain Manager. 
You can select the Manager using the dropdown bar in the screen. 
The Second Screen is AddEmployee which is used to Add the Employees into the database under a certain Manager. 
The below are the stored Procedures that I have used in the project. 
I also attached the screenshots of the Application and the database tables.

Stored Procedures


STORED PROCEDURE to populate employeetable gridview:

create procedure selectEmployeeData(IN mid varchar(50))
BEGIN
IF mid='All' THEN
SELECT employeeId, employeeLName, employeeFName FROM EMPLOYEE;
ELSE
SELECT employeeId, employeeLName, employeeFName FROM EMPLOYEE WHERE managerId=mid;
END IF;
END |



STORED PROCEDURE to insert values into roles table:

create procedure insertEmpRoles(IN empId varchar(20), IN role varchar(100))
BEGIN
INSERT INTO ROLES(employeeId, Roles) VALUES(empId,role);
END | 


STORED PROCEDURE to insert values into employee table:

create Procedure insertEmpDetails(IN eid varchar(20),IN efname varchar(100),IN elname
 varchar(100),IN emid varchar(20))
BEGIN
INSERT INTO employee(employeeId, employeeFName, employeeLName,managerId) VALUES(eid,efname,elname,em
id);
END |


GitHub Link:

https://github.com/bavasarala1/TylerApp

You can execute the project by downloading the WebApplication2.rar file in the github repository.


