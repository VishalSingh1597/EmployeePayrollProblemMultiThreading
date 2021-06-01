

create table payroll_Service(EmployeeId int ,EmployeeName varchar(20),PhoneNumber varchar(10) , Address varchar(20) , Department varchar(20),Gender char(1) ,BasicPay float , Deductions float ,TaxablePay float ,Tax float, NetPay float , StartDate DATETIME ,City varchar(10) ,Country varchar(10) );
select * from payroll_Service;  ---Display table



--insert Values of the table
insert into payroll_Service(EmployeeId,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,NetPay,StartDate,City,Country) values('1','Vishal','9930315160','Mumbai','Developer','M','210000','1000','100','1200','18000','2021-05-20','Mumbai','IN');
select * from payroll_Service;  ---Display table

