create procedure getFloors @department_id int = NULL
as
select floor_id, floor_desc from rel_floors_departments
join 
key_floors
on rel_floors_departments.floor_id = key_floors.id
where department_id = (case when @department_id is not null then @department_id else department_id end)
go

exec getFloors @department_id = 10