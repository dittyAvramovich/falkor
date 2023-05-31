create procedure getDepartments @floor_id int = NULL
as
select department_id, department_desc from rel_floors_departments
join 
key_departments
on rel_floors_departments.department_id = key_departments.id
where floor_id = (case when @floor_id is not null then @floor_id else floor_id end)
go

exec getDepartments @floor_id = 2